bin\Debug\CS426_Compiler.exe parser_test.txt > outfile.txt
	echo "This one works"
bin\Debug\CS426_Compiler.exe broken_parser_test1.txt >> outfile.txt
	echo "This one is broken because it does not use the equivalence expression"
bin\Debug\CS426_Compiler.exe broken_parser_test2.txt >> outfile.txt
	echo "This one is broken because it contains a broken array declaration"
bin\Debug\CS426_Compiler.exe broken_parser_test3.txt >> outfile.txt
	echo "This one is broken because it contains a broken method call"