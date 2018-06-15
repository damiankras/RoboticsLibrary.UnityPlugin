using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboticsLibrary.UnityPlugin.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private Robot robot = null;

        [TestInitialize]
        public void Initialize()
        {
            string path = @"D:\dev\Robotics\rl-ABB-YuMi\rlmdl\YuMi.xml";
            robot = new Robot(path);
        }

        [TestCleanup]
        public void Cleanup()
        {
            robot?.Dispose();
            robot = null;
        }

        [TestMethod]
        public void TestMethod1()
        {
            long dof = robot.Dof;
            var pos = robot.GetPosition();

            Transform transform = new Transform()
            {
                Translation = new Vector3(0.25, -0.01, 0.2),
                Rotation = new Vector3(-90d.DegreesToRadians(), 0, 0)
            };

            robot.SetGoal(0, transform);
            bool a = robot.SolveIk();
            var pos2 = robot.GetPosition().RadiansToDegrees();
        }

        [TestMethod]
        public void Robot_TestSetPosition()
        {
            long dof = robot.Dof;
            double[] posToSet = new double[dof];

            for (int i = 0; i < dof; i++)
            {
                posToSet[i] = i;
            }
            robot.SetPosition(posToSet);

            var pos = robot.GetPosition();

            for (int i = 0; i < dof; i++)
            {
                Assert.AreEqual(posToSet[i], pos[i]);
            }
        }

        [TestMethod]
        public void Robot_GetAcceleration()
        {
            var acceleration = robot.GetAcceleration(Unit.Degrees);
            Assert.IsNotNull(acceleration);
        }
    }
}