using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibSVMsharp.Tests;

[TestClass]
public class TestSVM
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_Train_ProblemIsNull_ThrowsException()
    {
        SVM.Train(null, new SVMParameter());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_Train_ParameterIsNull_ThrowsException()
    {
        SVM.Train(new SVMProblem(), null);
    }

    //[TestMethod]
    public void SVM_Train_Correct()
    {

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_CrossValidation_ProblemIsNull_ThrowsException()
    {
        SVM.CrossValidation(null, new SVMParameter(), 5, out var target);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_CrossValidation_ParameterIsNull_ThrowsException()
    {
        SVM.CrossValidation(new SVMProblem(), null, 5, out var target);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void SVM_CrossValidation_FoldNumberIsOutOfRange_ThrowsException()
    {
        SVM.CrossValidation(new SVMProblem(), new SVMParameter(), 1, out var target);
    }

    //[TestMethod]
    public void SVM_CrossValidation_Correct()
    {

    }

    [TestMethod]
    public void SVM_SaveModel_ModelIsNull_ReturnsFalse()
    {
        var success = SVM.SaveModel(null, Contants.CORRECT_MODEL_PATH_TO_BE_SAVED);
        Assert.IsFalse(success);
    }

    [TestMethod]
    public void SVM_SaveModel_FilenameIsInvalid_ReturnsFalse()
    {
        var success = SVM.SaveModel(new SVMModel(), "");
        Assert.IsFalse(success);
    }

    [TestMethod]
    public void SVM_SaveModel_Correct()
    {
        var model = SVM.LoadModel(Contants.CORRECT_MODEL_PATH_TO_BE_LOADED);
        Assert.IsNotNull(model);
        var success = SVM.SaveModel(model, Contants.CORRECT_MODEL_PATH_TO_BE_SAVED);
        Assert.IsTrue(success);
    }

    [TestMethod]
    public void SVM_LoadModel_FilenameIsInvalid_ReturnsNull()
    {
        Assert.IsNull(SVM.LoadModel(""));
    }

    [TestMethod]
    public void SVM_LoadModel_FilenameDoesNotExist_ReturnsNull()
    {
        Assert.IsFalse(System.IO.File.Exists(Contants.WRONG_MODEL_PATH_TO_BE_LOADED));
        Assert.IsNull(SVM.LoadModel(Contants.WRONG_MODEL_PATH_TO_BE_LOADED));
    }

    [TestMethod]
    public void SVM_LoadModel_ModelFileIsInvalid_ReturnsNull()
    {
        Assert.IsTrue(System.IO.File.Exists(Contants.INVALID_MODEL_PATH_TO_BE_LOADED));
        Assert.IsNull(SVM.LoadModel(Contants.INVALID_MODEL_PATH_TO_BE_LOADED));
    }

    [TestMethod]
    public void SVM_LoadModel_Correct()
    {
        var model = SVM.LoadModel(Contants.CORRECT_MODEL_PATH_TO_BE_LOADED);
        Assert.IsNotNull(model);
        Assert.IsNotNull(model.Labels);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_PredictValues_ModelIsNull_ThrowsException()
    {
        SVM.PredictValues(null, new SVMNode[5], out var values);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_PredictValues_ModelIsZero_ThrowsException()
    {
        SVM.PredictValues(IntPtr.Zero, new SVMNode[5], out var values);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_PredictValues_InputVectorIsNull_ThrowsException()
    {
        SVM.PredictValues(new SVMModel(), null, out var values);
    }

    //[TestMethod]
    public void SVM_PredictValues_Correct()
    {

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_Predict_ModelIsNull_ThrowsException()
    {
        SVM.Predict(null, new SVMNode[5]);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_Predict_ModelIsZero_ThrowsException()
    {
        SVM.Predict(IntPtr.Zero, new SVMNode[5]);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_Predict_InputVectorIsNull_ThrowsException()
    {
        SVM.Predict(new SVMModel(), null);
    }

    //[TestMethod]
    public void SVM_Predict_Correct()
    {

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_PredictProbability_ModelIsNull_ThrowsException()
    {
        double[] values;
        SVM.PredictProbability(null, new SVMNode[5], out values);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_PredictProbability_ModelIsZero_ThrowsException()
    {
        double[] values;
        SVM.PredictProbability(IntPtr.Zero, new SVMNode[5], out values);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_PredictProbability_InputVectorIsNull_ThrowsException()
    {
        double[] values;
        SVM.PredictProbability(new SVMModel(), null, out values);
    }

    //[TestMethod]
    public void SVM_PredictProbability_NotProbabilityModel_ReturnsNegativeNumber()
    {

    }

    //[TestMethod]
    public void SVM_PredictProbability_Correct()
    {

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_CheckParameter_ProblemIsNull_ThrowsException()
    {
        SVM.CheckParameter(null, new SVMParameter());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_CheckParameter_ParameterIsNull_ThrowsException()
    {
        SVM.CheckParameter(new SVMProblem(), null);
    }

    //[TestMethod]
    public void SVM_CheckParameter_Correct()
    {

    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void SVM_CheckProbabilityModel_ModelIsNull_ThrowsException()
    {
        SVM.CheckProbabilityModel(null);
    }

    //[TestMethod]
    public void SVM_CheckProbabilityModel_Correct()
    {

    }
}
