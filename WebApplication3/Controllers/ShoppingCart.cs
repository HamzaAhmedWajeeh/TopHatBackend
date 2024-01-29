using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Top_Hat_App.Models;

namespace Top_Hat_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly TopHatContext _dbContext;

        public ShoppingCartController(TopHatContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add item to the shopping cart
        [Authorize]
        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart(CartItemDTO cartItemDTO)
        {
            try
            {
                var userId = GetUserIdFromToken();
                var existingCartItem = await _dbContext.Carts
                    .FirstOrDefaultAsync(c => c.Userid == userId && c.Itemid == cartItemDTO.ItemId);

                if (existingCartItem != null)
                {
                    // Update quantity if item already exists in the cart
                    existingCartItem.Quantity += cartItemDTO.Quantity;
                }
                else
                {
                    // Add new item to the cart
                    var newCartItem = new Cart
                    {
                        Userid = userId,
                        Itemid = cartItemDTO.ItemId,
                        Quantity = cartItemDTO.Quantity
                    };

                    _dbContext.Carts.Add(newCartItem);
                }

                await _dbContext.SaveChangesAsync();

                return Ok("Item added to the shopping cart successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Checkout the items in the shopping cart
        [Authorize]
        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                var userId = GetUserIdFromToken();

                // Retrieve items in the cart for the user
                var cartItems = await _dbContext.Carts
                    .Where(c => c.Userid == userId)
                    .ToListAsync();

                if (cartItems.Count == 0)
                {
                    return BadRequest("Shopping cart is empty");
                }

                // Calculate the total amount
                decimal totalAmount = 0;
                foreach (var cartItem in cartItems)
                {
                    var menuItem = await _dbContext.MenuItems.FindAsync(cartItem.Itemid);
                    if (menuItem != null)
                    {
                        totalAmount += menuItem.Price * cartItem.Quantity;
                    }
                }

                // Create a new order
                var newOrder = new Order
                {
                    Userid = userId,
                    Orderdate = DateTime.Now,
                    Totalamount = totalAmount,
                    Orderstatus = "Pending", // You can set the initial order status
                    Paymentstatus = "Unpaid" // You can set the initial payment status
                };

                _dbContext.Orders.Add(newOrder);
                await _dbContext.SaveChangesAsync();

                // Create order items
                foreach (var cartItem in cartItems)
                {
                    var menuItem = await _dbContext.MenuItems.FindAsync(cartItem.Itemid);

                    var newOrderItem = new OrderItem
                    {
                        Orderid = newOrder.Id,
                        Itemid = cartItem.Itemid,
                        Quantity = cartItem.Quantity,
                        Subtotal = menuItem.Price * cartItem.Quantity
                    };

                    _dbContext.OrderItems.Add(newOrderItem);
                }

                // Clear the shopping cart
                _dbContext.Carts.RemoveRange(cartItems);
                await _dbContext.SaveChangesAsync();

                return Ok("Checkout successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Helper method to get the user ID from the JWT token
        private int GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            throw new ApplicationException("User ID not found in the token");
        }

        // DTO for receiving cart item data in requests
        public class CartItemDTO
        {
            public int ItemId { get; set; }
            public int Quantity { get; set; }
        }



        [Authorize]
        [HttpGet("CartSummary")]
        public async Task<IActionResult> GetCartSummary()
        {
            try
            {
                var userId = GetUserIdFromToken();

                // Retrieve items in the cart for the user
                var cartItems = await _dbContext.Carts
                    .Where(c => c.Userid == userId)
                    .ToListAsync();

                if (cartItems.Count == 0)
                {
                    return Ok(new CartSummaryDTO
                    {
                        TotalAmount = 0,
                        TotalItems = 0
                    });
                }

                // Calculate the total amount and total items
                decimal totalAmount = 0;
                int totalItems = 0;
                foreach (var cartItem in cartItems)
                {
                    var menuItem = await _dbContext.MenuItems.FindAsync(cartItem.Itemid);
                    if (menuItem != null)
                    {
                        totalAmount += menuItem.Price * cartItem.Quantity;
                        totalItems += cartItem.Quantity;
                    }
                }

                return Ok(new CartSummaryDTO
                {
                    TotalAmount = totalAmount,
                    TotalItems = totalItems
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        
        // DTO for returning cart summary data in responses
        public class CartSummaryDTO
        {
            public decimal TotalAmount { get; set; }
            public int TotalItems { get; set; }
        }



        [HttpPost("cancel/{orderId}")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            // Get the order by ID
            var order = await _dbContext.Orders.FindAsync(orderId);

            if (order == null)
            {
                return NotFound($"Order with ID {orderId} not found");
            }

            // Check if the user is the owner of the order or an admin
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var isAdmin = User.IsInRole("Admin");

            if (order.Userid != userId && !isAdmin)
            {
                return Forbid(); // User is not allowed to cancel this order
            }

            // Update order status to canceled
            if (isAdmin)
            {
                order.Orderstatus = "CanceledByAdmin";
            }
            else
            {
                order.Orderstatus = "CanceledByUser";
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();

            return Ok($"Order with ID {orderId} canceled successfully");
        }
    }
}

