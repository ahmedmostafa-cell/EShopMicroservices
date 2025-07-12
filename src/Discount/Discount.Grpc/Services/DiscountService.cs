namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext dbcontext , ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon =await dbcontext.Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if (coupon == null)
        {
            return new CouponModel
            {
                ProductName = "No Discount",
                Amount = 0,
                Description = "No Discount Desc"
            };
        }
        logger.LogInformation("Discount is retrieved for ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);
        var couponModel = coupon.Adapt<CouponModel>();

        return couponModel;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request,
        ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if(coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid coupon data"));

        try
        {
            dbcontext.Coupons.Add(coupon);
            await dbcontext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            logger.LogError(ex, "Database update failed");
            throw new RpcException(new Status(StatusCode.Internal, "Failed to save coupon to database"));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unexpected error during CreateDiscount");
            throw new RpcException(new Status(StatusCode.Unknown, "Unknown error occurred"));
        }
        var couponModel = coupon.Adapt<CouponModel>();
        logger.LogInformation("Discount is successfully created for ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);

        return couponModel;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid coupon data"));

        dbcontext.Coupons.Update(coupon);
        await dbcontext.SaveChangesAsync();
        var couponModel = coupon.Adapt<CouponModel>();
        logger.LogInformation("Discount is successfully updated for ProductName : {ProductName}, Amount : {Amount}", coupon.ProductName, coupon.Amount);

        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount
        (DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbcontext.Coupons
           .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if (coupon is null)
                   throw new RpcException(new Status(StatusCode.NotFound, 
                       $"Product with {request.ProductName} is not found"));

        dbcontext.Coupons.Remove(coupon);
        await dbcontext.SaveChangesAsync();
        logger.LogInformation("Discount is successfully deleted for ProductName " +
            ": {ProductName}", request.ProductName);

        return new DeleteDiscountResponse() { Success = true};   
    }
}
