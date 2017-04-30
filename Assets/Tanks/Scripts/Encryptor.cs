using System.Collections;
using System.Collections.Generic;
using System.Text;

public static class Encryptor{
	static int key = 7;

	public static string Convert(string text)
	{
		string s = "";
		char c;
		for (int i = 0; i < text.Length; i++)
		{
			c = text[i];
			c = (char)(c ^ key);
			s += c;
		}
		return s;
	}
}
