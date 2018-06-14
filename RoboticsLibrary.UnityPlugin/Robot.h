#pragma once

#include <memory.h>

#include <rl/mdl/Model.h>
#include <rl/mdl/Metric.h>
#include <rl/mdl/Kinematic.h>
#include <rl/mdl/Dynamic.h>
#include <rl/mdl/XmlFactory.h>
#include <rl/mdl/NloptInverseKinematics.h>

namespace RoboticsLibrary
{
	typedef struct Vector3
	{
		double x;
		double y;
		double z;
	} Vector3;

	typedef struct Transform
	{
		Vector3 Translation;
		Vector3 Rotation;
	} Transform;

	class Robot
	{
	private:
		std::shared_ptr<rl::mdl::Model> m_model = nullptr;
		std::shared_ptr<rl::mdl::NloptInverseKinematics> m_nlopt_ik = nullptr;

	public:
		Robot(std::string &pathToMdl);
		virtual ~Robot();

		size_t GetDof() const;
		void GetPosition(double *data) const;
		void SetPosition(const double *data);

		void SetGoal(size_t tcpId, Transform &transform);
		void ClearGoals();
		bool SolveIk();
	};
}
