# include <stdio.h>     // For input output functions
# include <stdlib.h>    // For memory allocation functions

//-------------------------Function prototypes----------------------------------------
using System.Numerics;

int** construct_matrix(int row, int col);
int** matrix_add(int** matrix1, int row1, int col1, int** matrix2, int row2, int col2);
int print_matrix_to_file(char* file_destination, int** matrix, int row, int col);
void print_matrix_to_screen(int** matrix, int row, int col);
int** make_zero_matrix(int row, int col);
int** make_identity_matrix(int row, int col);
void scale_matrix(int** matrix, int row, int col, int scalefactor);
int** find_transpose(int** matrix, int row, int col);
int** generate_random_matrix(int row, int col);
void read_matrix_from_file(char* destination);
void free_matrix(int row, int** matrix);

private char* GetFile_destination() { return file_destination; }
//-------------------------Function prototypes----------------------------------------

void main(void, char* file_destination, int random_matrix1)
{

    int** matrix1, **matrix2, **sum_matrix, **transpose_matrix, **random_matrix1, **random_matrix2;
    int columnnumber, rownumber;
    char* file_destination;

    printf("Enter the row number of the matrix:");
    scanf("%d", &rownumber);
    printf("\nEnter the column number of the matrix:");
    scanf("%d", &columnnumber);

    //Construct and print a zero matrix;
    matrix1 = make_zero_matrix(rownumber, columnnumber);
    printf("\nOutput of the make_zeromatrix function:\n");
    print_matrix_to_screen(matrix1, rownumber, columnnumber);

    //Construct and print an identity matrix;
    matrix2 = make_identity_matrix(rownumber, columnnumber);
    printf("\nOutput of the make_identity_matrix function:\n");
    if (matrix2 != NULL)
    {
        print_matrix_to_screen(matrix2, rownumber, columnnumber);

    }
  // Generate a random matrix named as random_matrix1
    int random_matrix1 = generate_random_matrix(rownumber, columnnumber);
    printf("\nOutput of the first random matrix:\n");
    print_matrix_to_screen(random_matrix1, rownumber, columnnumber);

    // Generate a random matrix named as random_matrix2
    random_matrix2 = generate_random_matrix(rownumber, columnnumber);
    printf("\nOutput of the second random matrix:\n");
    print_matrix_to_screen(random_matrix2, rownumber, columnnumber);

    //Calculate the sum of two matrices with given sizes and print to screen.
    sum_matrix = matrix_add(random_matrix1, rownumber, columnnumber, random_matrix2, rownumber, columnnumber);
    object value = printf("\nOutput of the sum function:\n");
    print_matrix_to_screen(sum_matrix, rownumber, columnnumber);

    //Scale sum_matrix with 2 and print
    scale_matrix(sum_matrix, rownumber, columnnumber, 2);
    printf("\nOutput of the scale_matrix function to the input sum_matrix with for scale factor=2:\n");
    print_matrix_to_screen(sum_matrix, rownumber, columnnumber);

    //Scale sum_matrix with 3 and print
    scale_matrix(sum_matrix, rownumber, columnnumber, 3);
    printf("\nOutput of the scale_matrix function to the input sum_matrix with for scale factor=3:\n");
    //Function behaves as if scale factor was equal to 6. Why?
    print_matrix_to_screen(sum_matrix, rownumber, columnnumber);

    //Scale a matrix with 3 and print a identity matrix;
    transpose_matrix = find_transpose(sum_matrix, rownumber, columnnumber);
    printf("\nOutput of the find transpose function\n");
    print_matrix_to_screen(transpose_matrix, columnnumber, rownumber); // why row column order is changed?

    //Print transpose of the sum_matrix to a file
    file_destination = "dosya.txt";
    if (print_matrix_to_file(file_destination, sum_matrix, rownumber, columnnumber) == 1)
    {
        printf("\nFile write OK!\n");
    }

    file_destination = "dosya.txt";
    read_matrix_from_file(file_destination);



    /*-------------------------------------------------------------
    |              FUNCTIONS FOR FREEING MEMORY                    |
     -------------------------------------------------------------*/

    // Empty the memory area for "matrix1" for further usage.
    free_matrix(rownumber, matrix1);
    if (matrix2 != NULL)
    {

        //Important!!! "matrix2" can have NULL value. In what conditions?. How?  

        free_matrix(rownumber, matrix2);

    }
    // Empty the memory area for "random_matrix1" for further usage.
    free_matrix(rownumber, random_matrix1);
    // Empty the memory area for "random_matrix1" for further usage.
    free_matrix(rownumber, random_matrix2);
    // Empty the memory area for "sum_matrix" for further usage.
    free_matrix(rownumber, sum_matrix);
    // Empty the memory area for "transpose_matrix" for further usage.
    free_matrix(columnnumber, transpose_matrix);

    /*-------------------------------------------------------------
  |       END OF FUNCTIONS FOR FREEING MEMORY                    |
     -------------------------------------------------------------*/


}

void print_matrix_to_screen(int random_matrix1, int rownumber, int columnnumber)
{
    throw new NotImplementedException();
}

void print_matrix_to_screen(int random_matrix1, int rownumber, int columnnumber)
{
    throw new NotImplementedException();
}

object printf(string v)
{
    throw new NotImplementedException();
}


// memory allocate for 2 dimensional matrix

int** construct_matrix(int row, int col)
{

    int** temp_matrix;
    int i;
    temp_matrix = (int**)malloc(row * sizeof(int*));

    for (i = 0; i < row; i++)
    {
        temp_matrix[i] = (int*)malloc(col * sizeof(int));
    }

    return temp_matrix;

}

// free allocated memory for matrix

void free_matrix(int row, int** matrix)
{

    int i;

    for (i = 0; i < row; i++)
    {
        free(matrix[i]);
    }

    free(matrix);
}

// find and return the sum of two matrices

int** matrix_add(int** matrix1, int row1, int col1, int** matrix2, int row2, int col2)
{

    int** sum_matrix;
    int i, j;

    if ((row1 != row2) || (col1 != col2))
    {
        printf("\nError in matrix_add function: Matrices are not in the same size\n");
        return NULL;
    }

    if (matrix1 == NULL || matrix2 == NULL)
    {
        printf("\nError in matrix add function: Cannot calculate sum. One of the matrices has null value!!!");
        return NULL;
    }

    sum_matrix = construct_matrix(row1, col1);


    for (i = 0; i < row1; i++)
    {
        for (j = 0; j < col1; j++)
        {
            // Hold sum in matrix1
            sum_matrix[i][j] = matrix1[i][j] + matrix2[i][j];
            //matrix1[i][j] = matrix1[i][j] - matrix2[i][j]; // For Subtraction
        }
    }
    //return sum of the matrices;
    return sum_matrix;
}

// prints the values of matrix to the file

int print_matrix_to_file(char* file_destination, int** matrix, int row, int col)
{

    FILE* fp;
    int i, j;
    fp = fopen(file_destination, "w");
    if (fp == NULL)
    {
        printf("\nCant open file\n");
        //Not successfull
        return 0;
    }
    fprintf(fp, "%3d %3d\n", row, col);

    for (i = 0; i < row; i++)
    {
        for (j = 0; j < col; j++)
        {
            fprintf(fp, "%3d", matrix[i][j]);

        }
        fprintf(fp, "\n");
    }

    fclose(fp);

    //Successfull 
    return 1;

}

// prints the values of matrix to the screen

void print_matrix_to_screen(int** matrix, int row, int col)
{

    int i, j;
    for (i = 0; i < row; i++)
    {
        for (j = 0; j < col; j++)
        {
            printf("%3d", matrix[i][j]);

        }
        printf("\n");
    }
}

// constructs a matrix filled with zeros

int** make_zero_matrix(int row, int col)
{

    int i, j;
    int** matrix = construct_matrix(row, col);
    for (i = 0; i < row; i++)
    {
        for (j = 0; j < col; j++)
        {
            matrix[i][j] = 0;
        }
    }
    return matrix;

}

// constructs an identity matrix 

int** make_identity_matrix(int row, int col)
{
    int i, j;
    int** matrix;

    if (row != col)
    {
        printf("\nError: Not square! Cannot be identity matrix");
        return NULL;
    }


    matrix = construct_matrix(row, col);

    for (i = 0; i < row; i++)
    {
        for (j = 0; j < col; j++)
        {
            if (i == j)
            {
                //printf("esit");
                matrix[i][j] = 1;
            }
            else
            {
                matrix[i][j] = 0;
            }
        }
    }

    return matrix;

}

// multiplies each element of a matrix with scale factor. 

void scale_matrix(int** matrix, int row, int col, int scalefactor)
{

    int i, j;
    for (i = 0; i < row; i++)
    {
        for (j = 0; j < col; j++)
        {
            //Below equals: matrix[i][j] = matrix[i][j] * scalefactor
            matrix[i][j] *= scalefactor;
        }
    }

}

// finds transpose of given matrix 

int** find_transpose(int** matrix, int row, int col)
{

    int i, j;
    int** transpose_matrix = construct_matrix(col, row); // why not construct_matrix(row,col)
    for (i = 0; i < col; i++)
    {
        for (j = 0; j < row; j++)
        {
            transpose_matrix[i][j] = matrix[j][i];
        }
    }
    return transpose_matrix;
}

// generates random matrix with each elements are between the interval [0 5]

int** generate_random_matrix(int row, int col)
{

    int i, j;
    int** matrix = construct_matrix(row, col);
    for (i = 0; i < row; i++)
    {
        for (j = 0; j < col; j++)
        {
            matrix[i][j] = rand() % 5;
        }
    }
    return matrix;
}

void read_matrix_from_file(char* destination)
{
    FILE* fp;
    int** my_temp_matrix;
    int row, col;
    int i, j;
    fp = fopen(destination, "r");
    if (fp == NULL)
    {
        printf("\nCant open file\n");
        //Not successfull
        return;
    }


    fscanf(fp, "%3d", &row);
    fscanf(fp, "%3d", &col);

    printf("\nRow Number: %3d Column Number: %3d", row, col);

    my_temp_matrix = construct_matrix(row, col);
    while (!feof(fp))
    {

        for (i = 0; i < row; i++)
        {
            for (j = 0; j < col; j++)
            {
                fscanf(fp, "%3d", &my_temp_matrix[i][j]);
            }
        }
    }

    fclose(fp);
    printf("\n");
    print_matrix_to_screen(my_temp_matrix, row, col);
    printf("\nFile read OK!\n\n");
}
