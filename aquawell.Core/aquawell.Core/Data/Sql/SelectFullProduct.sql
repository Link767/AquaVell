select
    productname,
    productwidth,
    productlength,
    productdepth,
    productdescription,
    productprice
from product
where productname = @productName