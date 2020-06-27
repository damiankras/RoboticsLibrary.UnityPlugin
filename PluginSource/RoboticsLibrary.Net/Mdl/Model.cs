using RoboticsLibrary.Net.Exceptions;
using System;
using System.IO;
using RoboticsLibrary.Net.Math;

// ReSharper disable InlineOutVariableDeclaration

namespace RoboticsLibrary.Net.Mdl
{
    public sealed class Model : IDisposable
    {
        private readonly ModelSafeHandle m_ptr;

        public Model()
        {
            ModelNative.RL_MDL_Model_New(out m_ptr).ThrowOnError();
            if (m_ptr.IsInvalid)
            {
                throw new Exception();
            }
        }

        public Model(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
                throw new ArgumentException();

            if (!File.Exists(path))
                throw new FileNotFoundException();

            ModelNative.RL_MDL_XmlFactory_Create(path, out m_ptr).ThrowOnError();
            if (m_ptr.IsInvalid)
            {
                throw new Exception();
            }
        }

        public bool AreColliding(UInt64 i, UInt64 j)
        {
            UInt32 result;
            ModelNative.RL_MDL_Model_AreColliding(m_ptr, i, j, out result).ThrowOnError();
            return result != 0;
        }

        public double[] GetAcceleration()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetAcceleration(m_ptr, result).ThrowOnError();
            return result;
        }

        public Unit[] GetAccelerationUnits()
        {
            UInt64 dof = GetDof();
            Unit[] result = new Unit[dof];
            ModelNative.RL_MDL_Model_GetAccelerationUnits(m_ptr, result).ThrowOnError();
            return result;
        }

        public UInt64 GetDof()
        {
            ModelNative.RL_MDL_Model_GetDof(m_ptr, out ulong value).ThrowOnError();
            return value;
        }

        public UInt64 GetDofPosition()
        {
            ModelNative.RL_MDL_Model_GetDofPosition(m_ptr, out ulong value).ThrowOnError();
            return value;
        }

        public double[] GetPosition()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetPosition(m_ptr, result).ThrowOnError();
            return result;
        }

        public double[] GetHomePosition()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetHomePosition(m_ptr, result).ThrowOnError();
            return result;
        }

        public double[] GetMaximum()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetMaximum(m_ptr, result).ThrowOnError();
            return result;
        }

        public double[] GetMinimum()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetMinimum(m_ptr, result).ThrowOnError();
            return result;
        }

        public double[] GetTorque()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetTorque(m_ptr, result).ThrowOnError();
            return result;
        }

        public double[] GetSpeed()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetSpeed(m_ptr, result).ThrowOnError();
            return result;
        }

        public double[] GetVelocity()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetVelocity(m_ptr, result).ThrowOnError();
            return result;
        }

        public void Dispose()
        {
            m_ptr?.Dispose();
        }
    }
}