// TestLoadLibrary.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "windows.h"
#include <iostream>
#include <string>
using namespace std;

int main(int argc, char *argv[])
{
	if (argc < 2)
	{
		cout << "USAGE: TestLoadLibrary <path>" << endl;
	}
	else
	{

		wstring s = wstring(argv[1], argv[1] + strlen(argv[1]));
		cout << "Loading library " << s.c_str() << "..." << endl;
		auto handle = LoadLibrary(s.c_str());

		if (handle == NULL)
		{
			cout << "Failed to load library" << endl;
			cout << "GetLastError() Returns: " << GetLastError() << endl;
		}
		else
		{
			cout << "Load Library succeeded";
			CloseHandle(handle);
		}
	}
    return 0;
}

