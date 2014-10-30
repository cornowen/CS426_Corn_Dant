bin\Debug\CS426_Compiler.exe working.txt > outfile.txt
	echo "This one works"
bin\Debug\CS426_Compiler.exe broken1.txt >> outfile.txt
	echo "This one is broken because it contains a float with 2 decimal points"
bin\Debug\CS426_Compiler.exe broken2.txt >> outfile.txt
	echo "This one is broken because it contains a variable name with 2 underscores"