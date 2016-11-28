using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.ui
{

	using MainAppData = com.alphatica.genotick.data.MainAppData;
	using Main = com.alphatica.genotick.genotick.Main;
	using MainSettings = com.alphatica.genotick.genotick.MainSettings;
	using TimePoint = com.alphatica.genotick.timepoint.TimePoint;


	internal class FileInput : BasicUserInput
	{
		internal const string delimiter = ":";
		private const string DATA_DIRECTORY_KEY = "dataDirectory";
		private string fileName;

		internal FileInput(string input)
		{
			if (!input.Contains(delimiter))
			{
				throw new Exception(string.Format("Config file input format is: '{0}'","input=file:/path/to/file"));
			}
			int pos = input.IndexOf(delimiter, StringComparison.Ordinal);
			fileName = input.Substring(pos + 1);
		}
		public override MainSettings getSettings(UserOutput output)
		{
			ISet<string> parsedKeys = new HashSet<string>();
			try
			{
				IDictionary<string, string> map = buildFileMap();
				MainSettings settings = MainSettings.Settings;
				MainAppData data = createData(map,parsedKeys,output);
				settings.startTimePoint = data.FirstTimePoint;
				settings.endTimePoint = data.LastTimePoint;
				settings.dataSettings = getDataDir(map,parsedKeys);
				applySettingsFromMap(settings,map,parsedKeys);
				checkAllSettingsParsed(map,parsedKeys);
				return settings;
			}
			catch (IOException e)
			{
				throw new Exception("Unable to read file " + fileName, e);
			}
			catch (IllegalAccessException e)
			{
				throw new Exception(e);
			}

		}

		private void checkAllSettingsParsed(IDictionary<string, string> map, ISet<string> parsedKeys)
		{
			if (map.Count == parsedKeys.Count)
			{
				return;
			}
			throw new Exception("Unable to match setting from config file: " + map.Keys.ToArray()[0]);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void applySettingsFromMap(com.alphatica.genotick.genotick.MainSettings settings, Map<String, String> map, Set<String> parsedKeys) throws IllegalAccessException
		private void applySettingsFromMap(MainSettings settings, IDictionary<string, string> map, ISet<string> parsedKeys)
		{
			Field[] fields = settings.GetType().GetFields();
			foreach (Field field in fields)
			{
				applySettingFromField(settings,map,field,parsedKeys);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void applySettingFromField(com.alphatica.genotick.genotick.MainSettings settings, Map<String, String> map, Field field, Set<String> parsedKeys) throws IllegalAccessException
		private void applySettingFromField(MainSettings settings, IDictionary<string, string> map, Field field, ISet<string> parsedKeys)
		{
			if (map.ContainsKey(field.Name))
			{
				string value = map[field.Name];
				parsedKeys.Add(field.Name);
				field.Accessible = true;
				switch (field.Type.Name)
				{
					case "java.lang.String":
						setString(field,settings,value);
						break;
					case "com.alphatica.genotick.timepoint.TimePoint":
						setTimePoint(field,settings,value);
						break;
					case "boolean":
						setBoolean(field, settings, value);
						break;
					case "int":
						setInt(field, settings, value);
						break;
					case "double":
						setDouble(field,settings,value);
						break;
					case "long":
						setLong(field, settings, value);
						break;
					default:
						throw new Exception("File config: Unable to match type " + field.Type.Name);
				}
				field.Accessible = false;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void setLong(Field field, com.alphatica.genotick.genotick.MainSettings settings, String value) throws IllegalAccessException
		private void setLong(Field field, MainSettings settings, string value)
		{
			long? l = long.Parse(value);
			field.setLong(settings,l);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void setDouble(Field field, com.alphatica.genotick.genotick.MainSettings settings, String value) throws IllegalAccessException
		private void setDouble(Field field, MainSettings settings, string value)
		{
			double? d = double.Parse(value);
			field.setDouble(settings,d);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void setInt(Field field, com.alphatica.genotick.genotick.MainSettings settings, String value) throws IllegalAccessException
		private void setInt(Field field, MainSettings settings, string value)
		{
			int? i = int.Parse(value);
			field.setInt(settings,i);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void setBoolean(Field field, com.alphatica.genotick.genotick.MainSettings settings, String value) throws IllegalAccessException
		private void setBoolean(Field field, MainSettings settings, string value)
		{
			bool? b = bool.Parse(value);
			field.setBoolean(settings,b);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void setTimePoint(Field field, com.alphatica.genotick.genotick.MainSettings settings, String value) throws IllegalAccessException
		private void setTimePoint(Field field, MainSettings settings, string value)
		{
			long? l = Convert.ToInt64(value);
			TimePoint tp = new TimePoint(l.Value);
			field.set(settings,tp);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void setString(Field field, com.alphatica.genotick.genotick.MainSettings settings, String value) throws IllegalAccessException
		private void setString(Field field, MainSettings settings, string value)
		{
			field.set(settings,value);
		}


		private MainAppData createData(IDictionary<string, string> map, ISet<string> parsedKeys, UserOutput output)
		{
			string dataDir = getDataDir(map,parsedKeys);
			return getData(dataDir,output);
		}

		private string getDataDir(IDictionary<string, string> map, ISet<string> parsedKeys)
		{
			string dataDir = Main.DEFAULT_DATA_DIR;
			if (map.ContainsKey(DATA_DIRECTORY_KEY))
			{
				dataDir = map[DATA_DIRECTORY_KEY];
				parsedKeys.Add(DATA_DIRECTORY_KEY);
			}
			return dataDir;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private Map<String, String> buildFileMap() throws java.io.IOException
		private IDictionary<string, string> buildFileMap()
		{
			IList<string> lines = buildLines();
			stripComments(lines);
			return createLinesMap(lines);
		}

		private IDictionary<string, string> createLinesMap(IList<string> lines)
		{
			IEnumerator<string> iterator = lines.GetEnumerator();
			IDictionary<string, string> map = new Dictionary<string, string>();
			Pattern pattern = Pattern.compile("(\\s*)(\\S+)(\\s+)(\\S+)");
			while (iterator.MoveNext())
			{
				string line = iterator.Current;
				Matcher matcher = pattern.matcher(line);
				while (matcher.find())
				{
					string key = matcher.group(2);
					checkDuplicateKey(map,key);
					map[key] = matcher.group(4);
				}
			}
			return map;
		}

		private void checkDuplicateKey(IDictionary<string, string> map, string key)
		{
			if (map.ContainsKey(key))
			{
				throw new Exception("Duplicate value in config file: " + key);
			}
		}

		private void stripComments(IList<string> lines)
		{
			string commentDelimiter = "#";
			for (int i = 0; i < lines.Count; i++)
			{
				string line = lines[i];
				if (line.Contains(commentDelimiter))
				{
					string[] array = line.Split(commentDelimiter, true);
					if (array.Length > 0)
					{
						lines[i] = array[0];
					}
				}
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private List<String> buildLines() throws java.io.IOException
		private IList<string> buildLines()
		{
			IList<string> list = new List<string>();
			using (System.IO.StreamReader br = new System.IO.StreamReader(new File(fileName)))
			{
				string line;
				while (!string.ReferenceEquals((line = br.readLine()), null))
				{
					list.Add(line);
				}
			}
			return list;
		}
	}

}