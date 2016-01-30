// ManagedExtensionCpp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


#using <mscorlib.dll>
#using <System.Xml.dll>
#using <ManagedLibrary.dll>


using namespace System;
using namespace System::Xml;
using namespace ManagedLibrary;


int _tmain(int argc, _TCHAR* argv[])
{
	//using managed class
	MyClass^ myClass = gcnew MyClass();

	myClass->Method1();
	int i = myClass->Method2();
	Result^ result1 = myClass->Method3();

	//call static method
	Result^ result2 = MyClass::SMethod3();
 


	XmlDocument^ doc = gcnew XmlDocument();
	doc->Load("http://www.tcmb.gov.tr/kurlar/today.xml");
	Console::WriteLine(doc->OuterXml);
	Console::ReadLine();

	return 0;
}

