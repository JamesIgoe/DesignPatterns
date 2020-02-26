using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.Threading;

namespace DesignPatterns
{
    //empty classes to make code build
    public class CubeInfo { }
    public class TrackedConnection { }
    public class TrackedConnections { }
    public class UserConfigurationList { }
    
    public interface ISubscriber
    {
        string UserId { get; set; }
        string Workstation { get; set; }
        string Title { get; set; }
        string Host { get; set; }
        string Port { get; set; }

        bool IsConnected { get; }
        TrackedConnections Tracker { get; set; }

        [OperationContract(IsOneWay = false)]
        void Attach(string userId, string workstation, string application);

        # region Methods used for Excel clients, used with delegate for status updates

        [OperationContract(IsOneWay = true)]
        void Update(IList<CubeInfo> message);

        [OperationContract(IsOneWay = false)]
        void Run();

        [OperationContract(IsOneWay = false)]
        void SendWorkbokForTracking(TrackedConnection item);

        UserConfigurationList Configuration { get; set; }

        # endregion

        # region Methods for legacy clients - single execution with return

        [OperationContract(IsOneWay = false)]
        IList<CubeInfo> GetAvailableCubeStatus();

        [OperationContract(IsOneWay = false)]
        CubeInfo GetActiveCube();

        # endregion

        # region Load Status methods - returns slices to load information

        [OperationContract(IsOneWay = false)]
        DataSet GetLoadStatusByDate(string viewDate);

        [OperationContract(IsOneWay = false)]
        DataSet GetLoadStatusBySource(string viewDate);

        [OperationContract(IsOneWay = false)]
        DataSet GetLoadStatusByRegion(string viewDate);

        # endregion
    }

    interface ISubscriberFacade
    {
        event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        DispatchingObservableCollection<CubeInfo> ActiveCubes { get; }
        DispatchingObservableCollection<CubeInfo> CubeList { get; }
        CubeInfo ActiveCube { get; }

        void Connect();
        void Detach();
        void Dispose();

        string Host { get; }
        string Port { get; }

        bool Status { get; }
        DateTime TimeStamp { get; }
        string AsString { get; }
        string ToString();
        bool UseWindowsAuthentication { get; }
    }
}

