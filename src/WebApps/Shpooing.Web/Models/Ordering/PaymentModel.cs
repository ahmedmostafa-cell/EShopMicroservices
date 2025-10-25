namespace Shpooing.Web.Models.Ordering;

public class PaymentModel
{
	public string CardName { get;  set; } = default!;

	public string CardNumber { get;  set; } = default!;

	public string Expiration { get;  set; } = default!;

	public string Cvv { get;  set; } = default!;

	public int PaymentMethod { get;  set; } = default!;
}
