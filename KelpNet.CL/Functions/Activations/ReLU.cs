﻿using System;
using System.Collections.Generic;
using Cloo;
using KelpNet.CL.Properties;

namespace KelpNet.CL
{
    [Serializable]
    public class ReLU : CPU.ReLU, ICompressibleActivation
    {
        const string FUNCTION_NAME = "ReLU";

        public ComputeKernel ForwardKernel { get; set; }
        public ComputeKernel BackwardKernel { get; set; }
        public string ActivateFunctionString { get; set; }
        public string ActivateKernelString { get; set; }
        public KeyValuePair<string, string>[] ActivationParameters { get; set; }
        public string ForwardKernelName { get; set; }
        public string BackwardKernelName { get; set; }

        public bool IsParallel { get; set; }

        void IParallelizable.InitParallel()
        {
            this.InitParallel();
        }

        bool IParallelizable.SetParallel(bool enable)
        {
            return this.SetParallel(enable);
        }

        public ReLU(string name = FUNCTION_NAME, string[] inputNames = null, string[] outputNames = null, bool gpuEnable = false) : base(name, inputNames, outputNames)
        {
            this.Initialize(FUNCTION_NAME, OpenCL.GetKernelSource(Resources.ReLU), null, name, inputNames, outputNames, gpuEnable);
        }
    }
}
