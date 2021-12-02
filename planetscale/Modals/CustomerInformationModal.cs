using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace planetscale.Modals
{
    public class CustomerInformationModal
    {
        public CustomerInformationModal()
        {
        }

        [HiddenInput]
        public long Id { get; set; } = default;

        [DataType(DataType.Text)]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string FirstName { get; set; } = string.Empty;

        [DataType(DataType.Text)]
        public string LastName { get; set; } = string.Empty;
    }
}
