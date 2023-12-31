﻿using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitShopping.Models
{
	[Table("ShoppingCarts")]
	[PrimaryKey(nameof(ShoppingCartId), nameof(ProductId),nameof(UserId))]
	public class ShoppingCart
	{
		public ShoppingCart() { }
		
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ShoppingCartId { get; set; }
		
		[ForeignKey(nameof(ProductId))]
		public int ProductId { get; set; }

        [ForeignKey(nameof(Users))]
		public int UserId { get; set; }

		public int Quantity { get; set; }


		public virtual Product Product { get; set; }

		public virtual Users users{ get; set; }

    }
}
