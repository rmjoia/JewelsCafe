﻿using System;
namespace JewelsCafe.Models
{
	public class Ingredient
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public bool IsAlergen { get; set; }
	}
}

