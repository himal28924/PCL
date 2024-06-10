int ComputeSquaresSum(int num)
{
    return square(num)*2;
}
int square(int num)
{
    return num * num;
}

int num = 5;
Console.WriteLine($"The sum of the squares of {num} and {num} is {ComputeSquaresSum(num)}");


