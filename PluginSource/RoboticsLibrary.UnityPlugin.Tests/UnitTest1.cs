using NUnit.Framework;
using RoboticsLibrary.Net.Math;
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

            using (Net.Mdl.Model model = new Net.Mdl.Model(path))
            {
                double[] acceleration = model.GetAcceleration();
                Unit[] accelerationUnits = model.GetAccelerationUnits();

                UInt64 bodies = model.GetBodies();
                UInt64 dof = model.GetDof();
                UInt64 dofPosition = model.GetDofPosition();
                UInt64 joints = model.GetJoints();
                UInt64 operationalDof = model.GetOperationalDof();

                double[] position = model.GetPosition();
                Unit[] positionUnits = model.GetPositionUnits();
                double[] homePos = model.GetHomePosition();

                double[] maximum = model.GetMaximum();
                double[] minimum = model.GetMinimum();
                double[] torque = model.GetTorque();
                Unit[] torqueUnits = model.GetTorqueUnits();

                double[] speed = model.GetSpeed();
                Unit[] speedUnits = model.GetSpeedUnits();

                double[] velocity = model.GetVelocity();
                Unit[] velocityUnits = model.GetVelocityUnits();
            }

            Assert.Pass();
        }
    }
}