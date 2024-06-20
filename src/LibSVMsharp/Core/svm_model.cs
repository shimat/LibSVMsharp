using System;
using System.Runtime.InteropServices;

namespace LibSVMsharp.Core;

[StructLayout(LayoutKind.Sequential)]
public struct svm_model
{
    [MarshalAs(UnmanagedType.Struct, SizeConst = 96)]
    public svm_parameter param;
    public int nr_class;
    public int l;
    public IntPtr SV; // svm_node**
    public IntPtr sv_coef; // double**
    public IntPtr rho; // double*
    public IntPtr probA;	// double*
    public IntPtr probB; // double*
    public IntPtr prob_density_marks;	/* probability information for ONE_CLASS */
    public IntPtr sv_indices; // int*
    public IntPtr label; // int*	
    public IntPtr nSV; // int*
    public int free_sv;
}
