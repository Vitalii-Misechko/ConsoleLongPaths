using System;
using System.IO;

namespace LongPaths {
	class Program {
		static void Main( string[] args ) {
			bool stillUsingLegacyPaths;

			AppContext.TryGetSwitch( "Switch.System.IO.UseLegacyPathHandling", out stillUsingLegacyPaths );
			Console.WriteLine( $"Switch.System.IO.UseLegacyPathHandling enabled: {stillUsingLegacyPaths}" );

			bool stillUsingBlockLongPaths;
			AppContext.TryGetSwitch( "Switch.System.IO.BlockLongPaths", out stillUsingBlockLongPaths );
			Console.WriteLine( $"Switch.System.IO.BlockLongPaths enabled: {stillUsingBlockLongPaths}" );


			string reallyLongDirectory = @"c:\Temp\LongPaths\" + new string( 'a', 200 ) + @"\" + new string( 'b', 200 )
				+ @"\" + new string( 'c', 200 );

			Console.WriteLine( $"Creating a directory that is {reallyLongDirectory.Length} characters long" );
			Directory.CreateDirectory( reallyLongDirectory );
			File.CreateText( reallyLongDirectory + @"\TextFile.txt" ).Close();
			Console.WriteLine("Press any key...");
			Console.ReadKey();
		}
	}
}
