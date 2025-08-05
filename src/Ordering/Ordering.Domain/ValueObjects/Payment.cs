using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Reflection.Emit;

namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Expiration { get; } = default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;

	protected Payment() { }

	private Payment(string cardName, string cardNumber, string expiration,
		string cVV, int paymentMethod)
	{
		CardName = cardName;
		CardNumber = cardNumber;
		Expiration = expiration;
		CVV = cVV;
		PaymentMethod = paymentMethod;
	}

	public static Payment Of(string cardName, string cardNumber, string expiration,
		string cVV, int paymentMethod)
	{
		ArgumentNullException.ThrowIfNullOrWhiteSpace(cardName);
		ArgumentNullException.ThrowIfNullOrWhiteSpace(cardNumber);
		ArgumentNullException.ThrowIfNullOrWhiteSpace(cVV);
		ArgumentOutOfRangeException.ThrowIfGreaterThan(cVV.Length , 3);

		return new Payment(cardName, cardNumber, expiration, cVV, paymentMethod);
	}

}
