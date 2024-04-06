#pragma once

#ifdef MATHDLL_EXPORTS
#define MATHDLL_API __declspec(dllexport)
#else
#define MATHDLL_API __declspec(dllimport)
#endif

extern "C" MATHDLL_API double Add(double a, double b);

extern "C" MATHDLL_API double Sub(double a, double b);

extern "C" MATHDLL_API double Mul(double a, double b);

extern "C" MATHDLL_API double Div(double a, double b);
