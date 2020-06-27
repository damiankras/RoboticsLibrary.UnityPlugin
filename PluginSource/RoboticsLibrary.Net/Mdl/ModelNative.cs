using RoboticsLibrary.Net.Exceptions;
using RoboticsLibrary.Net.Math;
using System;
using System.Runtime.InteropServices;

namespace RoboticsLibrary.Net.Mdl
{
    internal static class ModelNative
    {
        private const string DllName = "RoboticsLibrary.Native.dll";

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_New(out ModelSafeHandle ptr);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_Delete(ref IntPtr ptr);

        [DllImport(DllName, CharSet = CharSet.Ansi)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Globalization", "CA2101", Justification = "By design")]
        internal static extern ErrorNo RL_MDL_XmlFactory_Create(
            [MarshalAs(UnmanagedType.LPStr)] string path, out ModelSafeHandle ptr);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_AreColliding(
            [In] ModelSafeHandle ptr, [In] UInt64 i, [In] UInt64 j, [Out] out UInt32 dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetAcceleration(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetAccelerationUnits(
            [In] ModelSafeHandle ptr, Unit[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetBodies(
            [In] ModelSafeHandle ptr, [Out] out UInt64 dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetDof(
            [In] ModelSafeHandle ptr, [Out] out UInt64 dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetDofPosition(
            [In] ModelSafeHandle ptr, [Out] out UInt64 dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetJoints(
            [In] ModelSafeHandle ptr, [Out] out UInt64 dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetOperationalDof(
            [In] ModelSafeHandle ptr, [Out] out UInt64 dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetPosition(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetPositionUnits(
            [In] ModelSafeHandle ptr, Unit[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetHomePosition(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetMaximum(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetMinimum(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetTorque(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetTorqueUnits(
            [In] ModelSafeHandle ptr, Unit[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetSpeed(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetSpeedUnits(
            [In] ModelSafeHandle ptr, Unit[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetVelocity(
            [In] ModelSafeHandle ptr, double[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetVelocity(
            [In] ModelSafeHandle ptr, Unit[] dst);

        [DllImport(DllName)]
        internal static extern ErrorNo RL_MDL_Model_GetTool(
            [In] ModelSafeHandle ptr, [In] UInt64 i, double[] dst);
    }
}