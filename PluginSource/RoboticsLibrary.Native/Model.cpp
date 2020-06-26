#include "Model.h"

// ReSharper disable CppInconsistentNaming
// ReSharper disable CppClangTidyClangDiagnosticInconsistentDllimport

errno_t Execute(const std::function<void(void)>& lambda)
{
	try
	{
		lambda();
		return errorno_codes::SUCCESS;
	}
	catch (std::bad_alloc&)
	{
		return errorno_codes::STD_BAD_ALLOC;
	}
	catch (...)
	{
		return errorno_codes::UNKNOWN;
	}
}

template<typename T>
errno_t Execute(T* ptr, const std::function<void(T*)>& lambda)
{
	if (ptr == nullptr)
		return errorno_codes::NULLPTR;

	auto lambda1 = [ptr, &lambda]()
	{
		lambda(ptr);
	};

	return Execute(lambda1);
}

errno_t RL_MDL_Model_New(rl::mdl::Model* &ptr)
{
	ptr = nullptr;

	auto lambda = [&ptr]()
	{
		ptr = new rl::mdl::Model();
	};

	return Execute(lambda);
}

errno_t RL_MDL_Model_Delete(rl::mdl::Model* &ptr)
{
	if (ptr == nullptr)
		return errorno_codes::SUCCESS;

	auto lambda = [](rl::mdl::Model* ptr)
	{
		delete ptr;
		ptr = nullptr;
	};

	return Execute<rl::mdl::Model>(ptr, lambda);
}

errno_t RL_MDL_XmlFactory_Create(const char* path, rl::mdl::Model* &ptr)
{
	rl::mdl::XmlFactory factory;
	ptr = factory.create(path);;
	return 0;
	
	auto lambda = [&path, &ptr]()
	{
		rl::mdl::XmlFactory factory;
		ptr = factory.create(path);
	};

	return Execute(lambda);
}

errno_t RL_MDL_Model_AreColliding(
	rl::mdl::Model* ptr,
	const uint64_t& i,
	const uint64_t& j,
	uint32_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst, &i, &j](rl::mdl::Model* model)
		{
			*dst = model->areColliding(i, j) ? 1U : 0U;
		});
}

errno_t RL_MDL_Model_GetAcceleration(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getAcceleration();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetAccelerationUnits(rl::mdl::Model* ptr, int32_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getAccelerationUnits();
			memcpy(dst, source.data(), source.size() * sizeof(int32_t));
		});
}

errno_t RL_MDL_Model_GetBodies(rl::mdl::Model* ptr, uint64_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			*dst = model->getBodies();
		});
}

errno_t RL_MDL_Model_GetDof(rl::mdl::Model* ptr, uint64_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			*dst = model->getDof();
		});
}

errno_t RL_MDL_Model_GetDofPosition(rl::mdl::Model* ptr, uint64_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			*dst = model->getDofPosition();
		});
}

errno_t RL_MDL_Model_GetJoints(rl::mdl::Model* ptr, uint64_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			*dst = model->getJoints();
		});
}

errno_t RL_MDL_Model_GetOperationalDof(rl::mdl::Model* ptr, uint64_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			*dst = model->getOperationalDof();
		});
}

errno_t RL_MDL_Model_GetPosition(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getPosition();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetPositionUnits(rl::mdl::Model* ptr, int32_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getPositionUnits();
			memcpy(dst, source.data(), source.size() * sizeof(int32_t));
		});
}

errno_t RL_MDL_Model_GetHomePosition(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getHomePosition();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetMaximum(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getMaximum();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetMinimum(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getMinimum();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetTorque(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getTorque();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetTorqueUnits(rl::mdl::Model* ptr, int32_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getTorqueUnits();
			memcpy(dst, source.data(), source.size() * sizeof(int32_t));
		});
}

errno_t RL_MDL_Model_GetSpeed(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getSpeed();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetSpeedUnits(rl::mdl::Model* ptr, int32_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getSpeedUnits();
			memcpy(dst, source.data(), source.size() * sizeof(int32_t));
		});
}

errno_t RL_MDL_Model_GetVelocity(rl::mdl::Model* ptr, double* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getVelocity();
			memcpy(dst, source.data(), source.size() * sizeof(double));
		});
}

errno_t RL_MDL_Model_GetVelocityUnits(rl::mdl::Model* ptr, int32_t* dst)
{
	return Execute<rl::mdl::Model>(ptr, [dst](rl::mdl::Model* model)
		{
			auto source = model->getVelocityUnits();
			memcpy(dst, source.data(), source.size() * sizeof(int32_t));
		});
}

errno_t RL_MDL_Model_GetTool(rl::mdl::Model* ptr, const uint64_t& i, double* dst)
{
	//return Execute<rl::mdl::Model>(ptr, [dst, &i, &j](rl::mdl::Model* model)
	//{
	//	*dst = model->areColliding(i, j) ? 1U : 0U;
	//});

	return errorno_codes::NOT_IMPLEMENTED;
}