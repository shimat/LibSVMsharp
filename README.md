[![Github Actions Status](https://github.com/shimat/LibSVMsharp/workflows/Test/badge.svg)](https://github.com/shimat/LibSVMsharp/actions)  [![NuGet package](https://badge.fury.io/nu/LibSVMsharpCore.svg)](https://badge.fury.io/nu/LibSVMsharpCore)

## LibSVMsharp

LibSVMsharp is a simple and easy-to-use C# wrapper for Support Vector Machines. 
This library uses LibSVM version 3.23 with x64 support, released on 15th of July in 2018. 

For more information visit the official [libsvm](http://www.csie.ntu.edu.tw/~cjlin/libsvm/) webpage.

**This fork project will bring the original [ccerhan/LibSVMsharp](https://github.com/ccerhan/LibSVMsharp) project, which is no longer being updated, into .NET (Core) compatible.**


## How to Install

To install LibSVMsharp, download the [Nuget package](https://www.nuget.org/packages/LibSVMsharpCore) or run the following command in the Package Manager Console:

`PM> Install-Package LibSVMsharpCore`


## License
LibSVMsharp is released under the MIT License and libsvm is released under the [modified BSD Lisence](http://www.csie.ntu.edu.tw/~cjlin/libsvm/faq.html#f204) which is compatible with many free software licenses such as GPL.


## Example Codes

#### Simple Classification

```C#
SVMProblem problem = SVMProblemHelper.Load(@"dataset_path.txt");
SVMProblem testProblem = SVMProblemHelper.Load(@"test_dataset_path.txt");

SVMParameter parameter = new SVMParameter();
parameter.Type = SVMType.C_SVC;
parameter.Kernel = SVMKernelType.RBF;
parameter.C = 1;
parameter.Gamma = 1;

SVMModel model = SVM.Train(problem, parameter);

double[] target = new double[testProblem.Length];
for (int i = 0; i < testProblem.Length; i++)
  target[i] = SVM.Predict(model, testProblem.X[i]);

double accuracy = SVMHelper.EvaluateClassificationProblem(testProblem, target);
```

#### Simple Classification with Extension Methods

```C#
SVMProblem problem = SVMProblemHelper.Load(@"dataset_path.txt");
SVMProblem testProblem = SVMProblemHelper.Load(@"test_dataset_path.txt");

SVMParameter parameter = new SVMParameter();

SVMModel model = problem.Train(parameter);

double[] target = testProblem.Predict(model);
double accuracy = testProblem.EvaluateClassificationProblem(target);
```

#### Simple Regression
```C#
SVMProblem problem = SVMProblemHelper.Load(@"dataset_path.txt");
SVMProblem testProblem = SVMProblemHelper.Load(@"test_dataset_path.txt");

SVMParameter parameter = new SVMParameter();

SVMModel model = problem.Train(parameter);

double[] target = testProblem.Predict(model);
double correlationCoeff;
double meanSquaredErr = testProblem.EvaluateRegressionProblem(target, out correlationCoeff);
```
