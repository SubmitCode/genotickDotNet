using System;
using System.Collections.Generic;

namespace com.alphatica.genotick.population
{

	using RandomGenerator = com.alphatica.genotick.genotick.RandomGenerator;


	public class PopulationDAOFileSystem : PopulationDAO
	{
		private const string FILE_EXTENSION = ".prg";
		private readonly string robotsPath;
		private readonly Random random;

		public PopulationDAOFileSystem(string dao)
		{
			checkPath(dao);
			robotsPath = dao;
			random = RandomGenerator.assignRandom();
		}

		public virtual RobotName[] listRobotNames()
		{
			string[] files = listFiles(robotsPath);
			RobotName[] names = new RobotName[files.Length];
			for (int i = 0; i < files.Length; i++)
			{
				string longString = files[i].Substring(0,files[i].IndexOf('.'));
				names[i] = new RobotName(Convert.ToInt64(longString));
			}
			return names;
		}

		public virtual Robot getRobotByName(RobotName name)
		{
			File file = createFileForName(name);
			return getRobotFromFile(file);
		}

		public virtual IEnumerable<Robot> RobotList
		{
			get
			{
				return new IterableAnonymousInnerClass(this);
			}
		}

		private class IterableAnonymousInnerClass : IEnumerable<Robot>
		{
			private readonly PopulationDAOFileSystem outerInstance;

			public IterableAnonymousInnerClass(PopulationDAOFileSystem outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			internal class ListAvailableRobots : IEnumerator<Robot>
			{
				private readonly PopulationDAOFileSystem.IterableAnonymousInnerClass outerInstance;

				public ListAvailableRobots(PopulationDAOFileSystem.IterableAnonymousInnerClass outerInstance)
				{
					this.outerInstance = outerInstance;
				}

				internal readonly IList<RobotName> names;
				internal int index = 0;
				internal ListAvailableRobots(PopulationDAOFileSystem.IterableAnonymousInnerClass outerInstance)
				{
					this.outerInstance = outerInstance;
					names = outerInstance.outerInstance.AllRobotsNames;
				}
				public virtual bool hasNext()
				{
					return names.size() > index;
				}

				public virtual Robot next()
				{
					return outerInstance.outerInstance.getRobotByName(names.get(index++));
				}

				public virtual void remove()
				{
					throw new System.NotSupportedException("remove() not supported");
				}
			}
			public virtual IEnumerator<Robot> GetEnumerator()
			{
				return new ListAvailableRobots();
			}
		}

		public virtual int AvailableRobotsCount
		{
			get
			{
				return AllRobotsNames.Count;
			}
		}

		public virtual void saveRobot(Robot robot)
		{
			if (robot.Name == null)
			{
				robot.Name = AvailableName;
			}
			File file = createFileForName(robot.Name);
			saveRobotToFile(robot,file);
		}

		public virtual void removeRobot(RobotName robotName)
		{
			File file = createFileForName(robotName);
			bool result = file.delete();
			if (!result)
			{
				throw new DAOException("Unable to remove file " + file.AbsolutePath);
			}
		}

		public static Robot getRobotFromFile(File file)
		{
			try
			{
					using (ObjectInputStream ois = new ObjectInputStream(new BufferedInputStream(new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read))))
					{
					return (Robot) ois.readObject();
					}
			}
			catch (System.Exception e) when (e is ClassNotFoundException || e is IOException)
			{
				throw new DAOException(e);
			}
		}

		private void checkPath(string dao)
		{
			File file = new File(dao);
			if (!file.exists())
			{
				throw new DAOException(string.Format("Path '{0}' does not exist.",dao));
			}
			if (!file.Directory)
			{
				throw new DAOException(string.Format("Path '{0}' is not a directory.",dao));
			}
			if (!file.canRead())
			{
				throw new DAOException(string.Format("Path '{0}' is not readable.",dao));
			}
		}

		private IList<RobotName> AllRobotsNames
		{
			get
			{
				IList<RobotName> list = new List<RobotName>();
				string[] fileList = listFiles(robotsPath);
				if (fileList == null)
				{
					return list;
				}
				foreach (string name in fileList)
				{
					string shortName = name.Split("\\.", true)[0];
					long? l = long.Parse(shortName);
					list.Add(new RobotName(l.Value));
				}
				return list;
			}
		}

		private string [] listFiles(string dir)
		{
			File path = new File(dir);
			return path.list(new FilenameFilterAnonymousInnerClass(this, dir));
		}

		private class FilenameFilterAnonymousInnerClass : FilenameFilter
		{
			private readonly PopulationDAOFileSystem outerInstance;

			private string dir;

			public FilenameFilterAnonymousInnerClass(PopulationDAOFileSystem outerInstance, string dir)
			{
				this.outerInstance = outerInstance;
				this.dir = dir;
			}

			public override bool accept(File dir, string name)
			{
				return name.EndsWith(FILE_EXTENSION, StringComparison.Ordinal);
			}
		}

		private RobotName AvailableName
		{
			get
			{
				File file;
				long l;
				do
				{
					l = Math.Abs(random.nextLong());
					file = new File(robotsPath + l.ToString() + FILE_EXTENSION);
				} while (file.exists());
				return new RobotName(l);
			}
		}

		private File createFileForName(RobotName name)
		{
			return new File(robotsPath + File.separator + name.ToString() + FILE_EXTENSION);
		}

		private void saveRobotToFile(Robot robot, File file)
		{
			deleteFileIfExists(file);
			try
			{
					using (ObjectOutputStream ous = new ObjectOutputStream(new BufferedOutputStream(new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write))))
					{
					ous.writeObject(robot);
					}
			}
			catch (IOException ex)
			{
				throw new DAOException(ex);
			}
		}

		private void deleteFileIfExists(File file)
		{
			if (!file.exists())
			{
				return;
			}
			if (!file.delete())
			{
				throw new DAOException("Unable to delete file: " + file);
			}
		}


	}

}