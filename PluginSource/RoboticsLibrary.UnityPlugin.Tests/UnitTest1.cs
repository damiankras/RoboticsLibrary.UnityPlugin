using NUnit.Framework;
using System;
using System.Diagnostics;

namespace RoboticsLibrary.UnityPlugin.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }

            string path = @"D:\dev\Robotics\rl-ABB-YuMi\rlmdl\YuMi.xml";

            Net.Mdl.Model model = new Net.Mdl.Model(path);

            UInt64 dof = model.GetDof();
            UInt64 dofPosition = model.GetDofPosition();
            double[] acceleration = model.GetAcceleration();
            double[] position = model.GetPosition();

            double[] homePos = model.GetHomePosition();
            double[] max = model.GetMaximum();
            double[] min = model.GetMinimum();
            double[] torque = model.GetTorque();
            double[] speed = model.GetSpeed();
            double[] velocity = model.GetVelocity();

            model.Dispose();

            Assert.Pass();
        }
    }
}