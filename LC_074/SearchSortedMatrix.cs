namespace LeetCode.LC_074;

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        return SearchMatrixCoordinates(matrix, target) != null;
    }

    public (int row, int column)? SearchMatrixCoordinates(int[][] matrix, int target)
    {
        var rowsCount = matrix.Length;
        var columnsCount = matrix.Length == 0 ? 0 : matrix[0].Length;
        if (rowsCount == 0 || columnsCount == 0)
        {
            return null;
        }

        for (var row = 0; row < rowsCount; row++)
        {
            var column = columnsCount - 1;
            while (true)
            {
                if (column < 0)
                {
                    return null;
                }

                if (matrix[row][column] > target)
                {
                    column--;
                }
                else if (matrix[row][column] == target)
                {
                    return (row, column);
                }
                else if (matrix[row][column] < target)
                {
                    // we found a column with the biggest number before target in a current row.
                    // now we don't need any columns from right side
                    columnsCount = column + 1; 
                    break;
                }
            }
        }

        return null;
    }


    public (int row, int column)? BinarySearchMatrixCoordinates(int[][] matrix, int target)
    {
        int rows = matrix.Length;
        int cols = rows == 0 ? 0 : matrix[0].Length;
        if (rows == 0 || cols == 0) return null;

        int rowStart = 0, rowEnd = rows - 1;
        int colStart = 0, colEnd = cols - 1;

        while (rowStart <= rowEnd && colStart <= colEnd)
        {
            // Binary search in the middle row
            int midRow = (rowStart + rowEnd) / 2;
            int colIndex = BinarySearchRow(matrix[midRow], colStart, colEnd, target);
            if (colIndex != -1) return (midRow, colIndex);

            // Binary search in the middle column
            int midCol = (colStart + colEnd) / 2;
            int rowIndex = BinarySearchColumn(matrix, rowStart, rowEnd, midCol, target);
            if (rowIndex != -1) return (rowIndex, midCol);

            // Adjust search space
            if (matrix[midRow][midCol] < target)
            {
                rowStart = midRow + 1;
                colStart = midCol + 1;
            }
            else
            {
                rowEnd = midRow - 1;
                colEnd = midCol - 1;
            }
        }

        return null;
    }

    private int BinarySearchRow(int[] row, int left, int right, int target)
    {
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (row[mid] == target) return mid;
            if (row[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    private int BinarySearchColumn(int[][] matrix, int top, int bottom, int col, int target)
    {
        while (top <= bottom)
        {
            int mid = (top + bottom) / 2;
            if (matrix[mid][col] == target) return mid;
            if (matrix[mid][col] < target) top = mid + 1;
            else bottom = mid - 1;
        }
        return -1;
    }

}

public class TestCases
{
    [Test]
    public void Test1()
    {
        var matrix = new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } };
        var target = 3;

        var solution = new Solution();
        var result = solution.SearchMatrix(matrix, target);

        Assert.True(result);
    }

    [Test]
    public void Test2()
    {
        var matrix = new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } };
        var target = 13;

        var solution = new Solution();
        var result = solution.SearchMatrix(matrix, target);

        Assert.False(result);
    }
}