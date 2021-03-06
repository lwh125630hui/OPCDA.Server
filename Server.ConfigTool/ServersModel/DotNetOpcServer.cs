//_______________________________________________________________
//  Title   : DotNetOpcServer
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2017, CAS LODZ POLAND.
//  TEL: +48 608 61 98 99 
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using OpcRcw;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CAS.CommServer.DA.Server.ConfigTool.ServersModel
{
  /// <summary>
  /// A class that describes a wrapped object.
  /// </summary>
  public class DotNetOpcServer : DotNetOpcServerBase
  {

    #region Constructors
    /// <summary>
    /// The default constructor.
    /// </summary>
    public DotNetOpcServer() : base() { }
    /// <summary>
    /// Initializes the object with a <see cref="Guid"/>.
    /// </summary>
    public DotNetOpcServer(Guid clsid) : base(clsid)
    {
      m_codebase = clsid.GetExecutablePath();
      m_systemType = GetSystemType(clsid, m_codebase);
      m_specifications = GetSpecifications(m_systemType);
    }
    /// <summary>
    /// Sets private members to default values.
    /// </summary>
    protected override void Initialize()
    {
      base.Initialize();
      m_codebase = null;
      m_systemType = null;
      m_specifications = Specifications.None;
    }
    #endregion

    #region Public
    /// <summary>
    /// The file path for the DLL containing the wrapped object.
    /// </summary>
    public string Codebase
    {
      get { return m_codebase; }
    }
    /// <summary>
    /// The system type of the server object.
    /// </summary>
    public Type SystemType
    {
      get { return m_systemType; }
    }
    /// <summary>
    /// The specifications supported by the .NET server.
    /// </summary>
    public Specifications Specifications
    {
      get { return m_specifications; }
    }
    /// <summary>
    /// Returns the wrapped objects registered on the local machine.
    /// </summary>
    public static List<DotNetOpcServer> EnumServers()
    {
      // enumerate clsids.
      List<Guid> clsids = Utils.EnumClassesInCategories(CommonDefinitions.CATID_DotNetOpcServers);
      // initialize objects.
      List<DotNetOpcServer> servers = new List<DotNetOpcServer>();
      for (int ii = 0; ii < clsids.Count; ii++)
        servers.Add(new DotNetOpcServer(clsids[ii]));
      return servers;
    }
    /// <summary>
    /// Registers the types in the specified assembly.
    /// </summary>
    public static void RegisterAssembly(string filePath)
    {
      List<System.Type> _types = Utils.RegisterComTypes(filePath);
      foreach (System.Type type in _types)
      {
        try
        {
          // verify that the object implements the wrapper object interface.
          System.Type[] interfaces = type.GetInterfaces();
          // must manually compare guids because unrelated assemblies that define the same
          // COM interface have different .NET interface types even if the underlying COM 
          // interface is the same.
          for (int ii = 0; ii < interfaces.Length; ii++)
            if (interfaces[ii].GUID == typeof(IOPCWrappedServer).GUID)
              Utils.RegisterClassInCategory(type.GUID, CommonDefinitions.CATID_DotNetOpcServers, "OPC Wrapped Server Objects");
        }
        catch
        {
          // ignore types that don't have a default constructor.
          continue;
        }
      }
    }
    /// <summary>
    /// Registers the types in the specified assembly.
    /// </summary>
    public static void UnregisterAssembly(string filePath)
    {
      List<System.Type> _types = Utils.UnregisterComTypes(filePath);
      foreach (System.Type type in _types)
      {
        try
        {
          Utils.UnregisterClassInCategory(type.GUID, CommonDefinitions.CATID_DotNetOpcServers);
        }
        catch
        {
          continue;
        }
      }
    }
    #endregion

    #region Overridden Methods
    /// <summary>
    /// Converts the object to a displayable string.
    /// </summary>
    public override string ToString()
    {
      if (!String.IsNullOrEmpty(ProgId))
      {
        return ProgId;
      }

      if (CLSID == Guid.Empty)
      {
        return "(unknown)";
      }

      return CLSID.ToString();
    }
    #endregion

    #region Private Members
    private string m_codebase;
    private Type m_systemType;
    private Specifications m_specifications;
    /// <summary>
    /// Finds the system type for the .NET implementation of an OPC server.
    /// </summary>
    private static Type GetSystemType(Guid clsid, string codebase)
    {
      if (clsid == Guid.Empty || String.IsNullOrEmpty(codebase))
        return null;
      try
      {
        Assembly assembly = Assembly.LoadFrom(codebase);
        foreach (Type type in assembly.GetExportedTypes())
          if (type.GUID == clsid)
            return type;
        return null;
      }
      catch
      {
        return null;
      }
    }
    /// <summary>
    /// Finds the OPC specifications supported by the .NET server.
    /// </summary>
    private static Specifications GetSpecifications(Type systemType)
    {
      if (systemType == null)
        return Specifications.None;
      Specifications specifications = Specifications.None;
      foreach (Type _interfaces in systemType.GetInterfaces())
      {
        if (_interfaces.GUID == typeof(OpcRcw.Da.IOPCItemProperties).GUID)
          specifications |= Specifications.DA2;
        if (_interfaces.GUID == typeof(OpcRcw.Da.IOPCBrowse).GUID)
          specifications |= Specifications.DA3;
        if (_interfaces.GUID == typeof(OpcRcw.Ae.IOPCEventServer).GUID)
          specifications |= Specifications.AE;
        if (_interfaces.GUID == typeof(OpcRcw.Hda.IOPCHDA_Server).GUID)
          specifications |= Specifications.HDA;
      }
      return specifications;
    }
    #endregion
  }

}
