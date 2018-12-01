/****************************************************/
/* File: main.c                                     */
/* Main program for TINY compiler                   */
/* Compiler Construction: Principles and Practice   */
/* Kenneth C. Louden                                */
/****************************************************/

#include "globals.h"
#include "util.h"
#include "scan.h"
#include "parse.h"


/* allocate global variables */
int lineno = 0;
FILE * source;
FILE * listing;
FILE * code;

/* allocate and set tracing flags */
int EchoSource = FALSE;
int TraceScan = FALSE;
int TraceParse = FALSE;
int TraceAnalyze = FALSE;
int TraceCode = FALSE;

int Error = FALSE;

extern __declspec(dllexport) void getSyntaxTree(char* sourceFileFullName, char* savedFileFullName);


/*
 ����ȫ·��ΪsourceFileFullName��Դ�����ļ�����ɨ��õ����﷨����ӡ��ȫ·��ΪsavedFileFullName���ļ���
*/
void getSyntaxTree(char* sourceFileFullName, char* savedFileFullName)
{
	TreeNode * syntaxTree;

	source = fopen(sourceFileFullName, "r");

	if (source == NULL)
	{
		fprintf(stderr, "File %s not found\n", sourceFileFullName);
		exit(1);
	}

	listing = fopen(savedFileFullName, "w");
	fprintf(listing, "TINY COMPILATION: %s\n\n", sourceFileFullName);

	// ��������
	linepos = 0;  /* current position in LineBuf */
	bufsize = 0;  /* current size of buffer string */
	EOF_flag = 0; /* corrects ungetNextChar behavior on EOF */
	
	syntaxTree = parse();

	fprintf(listing, "Syntax tree:\n\n");
	printTree(syntaxTree);

	fclose(source);
	fclose(listing);
}

/*
int main()
{
	getSyntaxTree("E:\\DoWhileSample.txt", "E:\\DoWhileSample_SyntaxTree.txt");
	//getSyntaxTree("E:\\ForSample.txt", "E:\\ForSample_SyntaxTree.txt");
	//getSyntaxTree("E:\\WhileSample.txt", "E:\\WhileSample_SyntaxTree.txt");
	return 0;
}

*/