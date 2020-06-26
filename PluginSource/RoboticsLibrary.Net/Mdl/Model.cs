using System;
using System.IO;

namespace RoboticsLibrary.Net.Mdl
{
    public class Model : IDisposable
    {
        private readonly ModelSafeHandle m_ptr;

        public Model()
        {
            var error = ModelNative.RL_MDL_Model_New(out m_ptr);
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

            //int error = ModelNative.RL_MDL_XmlFactory_Create(path, out m_ptr);
            int error = ModelNative.RL_MDL_XmlFactory_Create(path, out m_ptr);
            if (m_ptr.IsInvalid)
            {
                throw new Exception();
            }
        }

        public double[] GetAcceleration()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetAcceleration(m_ptr, result);
            return result;
        }

        public UInt64 GetDof()
        {
            int error = ModelNative.RL_MDL_Model_GetDof(m_ptr, out ulong value);
            return value;
        }

        public UInt64 GetDofPosition()
        {
            int error = ModelNative.RL_MDL_Model_GetDofPosition(m_ptr, out ulong value);
            return value;
        }

        public double[] GetPosition()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetPosition(m_ptr, result);
            return result;
        }

        public double[] GetHomePosition()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetHomePosition(m_ptr, result);
            return result;
        }

        public double[] GetMaximum()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetMaximum(m_ptr, result);
            return result;
        }

        public double[] GetMinimum()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetMinimum(m_ptr, result);
            return result;
        }

        public double[] GetTorque()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetTorque(m_ptr, result);
            return result;
        }

        public double[] GetSpeed()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetSpeed(m_ptr, result);
            return result;
        }

        public double[] GetVelocity()
        {
            UInt64 dof = GetDof();
            double[] result = new double[dof];
            ModelNative.RL_MDL_Model_GetVelocity(m_ptr, result);
            return result;
        }

        public virtual void Dispose()
        {
            m_ptr.Dispose();
        }
    }
}