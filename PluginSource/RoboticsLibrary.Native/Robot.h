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

	typedef struct TransformRaw
	{
		double m00;
		double m01;
		double m02;
		double m03;
		double m10;
		double m11;
		double m12;
		double m13;
		double m20;
		double m21;
		double m22;
		double m23;
		double m30;
		double m31;
		double m32;
		double m33;
	} TransformRaw;

	union TransformArray
	{
		TransformRaw raw;
		double _array[16];
	};

	class Robot
	{
	private:
		std::shared_ptr<rl::mdl::Model> m_model = nullptr;
		std::shared_ptr<rl::mdl::NloptInverseKinematics> m_nlopt_ik = nullptr;

	public:
		Robot(std::string& pathToMdl);
		virtual ~Robot();

		rl::mdl::Model& GetModel();

		size_t GetDof() const;
		void GetPosition(double* data) const;
		void SetPosition(const double* data);

		void SetGoal(size_t tcpId, Transform& transform);
		void ClearGoals();
		bool SolveIk();
	};
}
