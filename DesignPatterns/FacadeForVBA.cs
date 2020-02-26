using System;
using System.Runtime.InteropServices;

namespace DesignPatterns
{
    /// <summary>
    /// Interace to expose VSTO/COM obects for COM and Excel
    /// Used by class below
    /// </summary>
    [ComVisible(true)]
    [Guid("B523844E-1A41-4118-A0F0-FDFA7BCD77C9")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IAdapterForVba
    {
        //signatures for methods acessible to VBA go here
        //exists here and in class
    }

    /// <summary>
    /// Class to expose items to VBA and ehotr COM application
    /// </summary>
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class AdapterForVba : IAdapterForVba
    {
        public AdapterForVba()
        {
            //methods to expose go here
            //exists here and in interface
        }
    }
}