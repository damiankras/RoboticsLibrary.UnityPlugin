using RoboticsLibrary.Net.Exceptions;
using System;
using System.Runtime.InteropServices;

namespace RoboticsLibrary.Net.Mdl
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class ModelSafeHandle : SafeHandle
    {
        public ModelSafeHandle()
            : base(IntPtr.Zero, true)
        {
        }

        protected override bool ReleaseHandle()
        {
            IntPtr ptr = handle;
            bool result = ModelNative.RL_MDL_Model_Delete(ref ptr) == ErrorNo.Success;
            handle = IntPtr.Zero;
            return result;
        }

        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}