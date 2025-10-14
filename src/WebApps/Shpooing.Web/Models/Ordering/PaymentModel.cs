namespace Shpooing.Web.Models.Ordering;

public class PaymentModel
{
	public string CardName { get; private set; } = default!;

	public string CardNumber { get; private set; } = default!;

	public string Expiration { get; private set; } = default!;

	public string Cvv { get; private set; } = default!;

	public int PaymentMethod { get; private set; } = default!;
}
