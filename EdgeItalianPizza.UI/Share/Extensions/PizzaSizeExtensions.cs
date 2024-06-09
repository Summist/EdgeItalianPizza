using EdgeItalianPizza.UI.Share.Enums;

namespace EdgeItalianPizza.UI.Share.Mappers;

internal static class PizzaSizeExtensions
{
    /// <summary>
    /// Размер маленькой пиццы.
    /// </summary>
    private const int SmallSizeValue = 25;
    /// <summary>
    /// Размер средней пиццы.
    /// </summary>
    private const int MediumSizeValue = 30;
    /// <summary>
    /// Размер большой пиццы.
    /// </summary>
    private const int LargeSizeValue = 35;

    /// <summary>
    /// Размер изображения для маленького размера пиццы.
    /// </summary>
    private const int SmallImageSize = 325;
    /// <summary>
    /// Размер изображения для среднего размера пиццы.
    /// </summary>
    private const int MediumImageSize = 375;
    /// <summary>
    /// Размер изображения для большого размера пиццы.
    /// </summary>
    private const int LargeImageSize = 425;

    private static readonly Dictionary<int, PizzaSize> _convertRules = new()
    {
        { SmallSizeValue,  PizzaSize.Small  },
        { MediumSizeValue, PizzaSize.Medium },
        { LargeSizeValue,  PizzaSize.Large  }
    };

    private static readonly Dictionary<PizzaSize, int> _convertRulesToImage = new()
    {
        { PizzaSize.Small,  SmallImageSize  },
        { PizzaSize.Medium, MediumImageSize },
        { PizzaSize.Large,  LargeImageSize  }
    };

    /// <summary>
    /// Конвертировать число в <see cref="PizzaSize"/>.
    /// </summary>
    /// <param name="size">Размер пиццы.</param>
    /// <returns>
    /// Возвращает <see cref="PizzaSize.None"/>, если вводимый размер существует, в противном случае <see cref="PizzaSize"/> со значением размера.
    /// </returns>
    internal static PizzaSize ToPizzaSize(this int size)
    {
        if (!_convertRules.TryGetValue(size, out PizzaSize result))
            return PizzaSize.None;

        return result;
    }

    /// <summary>
    /// Конвретировать размер пиццы в размер для изображения.
    /// </summary>
    /// <param name="size">Размер пиццы.</param>
    /// <returns>
    /// Возвращает размер изображения, если <see cref="PizzaSize"/> не равен <see cref="PizzaSize.None"/>,
    /// в противном случае -1.
    /// </returns>
    internal static int ToImageSize(this PizzaSize size)
    {
        const int NegativeResultValue = -1;

        if (!_convertRulesToImage.TryGetValue(size, out int result))
            return NegativeResultValue;

        return result;
    }
}
