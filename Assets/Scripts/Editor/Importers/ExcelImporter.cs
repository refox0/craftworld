using System.IO;

using UnityEditor;

public class ExcelImporter : AssetPostprocessor
{
	static void OnPostprocessAllAssets(string[] importedAssets,
	                                   string[] deletedAssets,
	                                   string[] movedAssets,
	                                   string[] movedFromAssetPaths)
	{
		bool refreshNeeded = false;
		
		foreach(var assetPath in importedAssets)
		{
			if(Path.GetExtension(assetPath) == ".xlsx")
			{
				FileStream stream = File.Open( assetPath , FileMode.Open , FileAccess.Read );
				byte[] readbytes = new byte[ stream.Length ];
				stream.Read( readbytes , 0 , (int)stream.Length );
				
				string newAssetPath = Path.ChangeExtension(assetPath, ".cfg");
				
				byte[] com = GameDefine.Compress( readbytes );
				FileStream streamWrite = File.Open( newAssetPath , FileMode.OpenOrCreate , FileAccess.Write );
				streamWrite.Write( com , 0 , com.Length );
				
				stream.Close();
				streamWrite.Close();
			}
		}
		
		if(refreshNeeded)
			AssetDatabase.Refresh();
	}
}
