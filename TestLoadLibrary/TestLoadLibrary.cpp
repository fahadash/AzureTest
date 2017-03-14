// TestLoadLibrary.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "windows.h"
#include <iostream>
#include <string>
#include <sstream>
#include <fstream>
using namespace std;

int main(int argc, char *argv[])
{
	stringstream str;

	if (argc < 2)
	{
		str << "USAGE: TestLoadLibrary <path>" << endl;
	}
	else
	{

		wstring s = wstring(argv[1], argv[1] + strlen(argv[1]));
		str << "Loading library " << s.c_str() << "..." << endl;
		auto handle = LoadLibrary(s.c_str());

		if (handle == NULL)
		{
			str << "Failed to load library" << endl;
			str << "GetLastError() Returns: " << GetLastError() << endl;
		}
		else
		{
			str << "Load Library succeeded";
			CloseHandle(handle);
		}

	}

	string fin = str.str();


	cout << fin;

	if (argc > 2)
	{
		ofstream f(argv[2]);
		f << fin;
		f.flush();
		f.close();
	}
    return 0;
}

