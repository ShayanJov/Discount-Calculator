double regularPrice = 0;
int discountPercentage = 0;
bool regularPriceInputFailed = true;
bool discountPercentageInputFailed = true;

while (regularPriceInputFailed || discountPercentageInputFailed)
{
    if (regularPriceInputFailed) AskRegularPrice();
    else if (discountPercentageInputFailed) AskDiscountPercentage();
}
Console.Clear();
Console.WriteLine($"Regular price: £{regularPrice}");
Console.WriteLine($"Discount: {discountPercentage}%");
Console.WriteLine($"Your price after discount is: £{DiscountCalculator(regularPrice, discountPercentage)}");

void AskRegularPrice()
{
    var regularPriceInput = AskQuestionGetDoubleResult("What is the regular price? ");
    if (regularPriceInput is not null)
    {
        if (regularPriceInput < 0)
        {
            Console.Clear();
            Console.WriteLine
                ($"Price can not be {regularPriceInput}! Please enter a new value more than 0.");
        }
        else
        {
            regularPrice = regularPriceInput ?? 0;
            regularPriceInputFailed = false;
            Console.Clear();
        }
    }
}

void AskDiscountPercentage()
{
    var discountPercentageInput = AskQuestionGetDoubleResult("What is the discount percentage? ");
    if (discountPercentageInput is not null)
    {
        if (discountPercentageInput < 0 || discountPercentageInput > 100)
        {
            Console.Clear();
            Console.WriteLine
                    ($"Discount percentage can not be {discountPercentageInput}!" +
                    $" please enter a value between 0 and 100.");
        }
        else
        {
            discountPercentage = (int)(discountPercentageInput ?? 0);
            discountPercentageInputFailed = false;
        }
    }
}

double? AskQuestionGetDoubleResult(string question)
{
    try
    {
        Console.WriteLine(question);
        return Convert.ToDouble(Console.ReadLine());

    }
    catch (Exception)
    {
        Console.WriteLine("Input is not a number!");
        return null;
    }
}

double DiscountCalculator(double p, double d) => p * (100 - d) / 100;
