using Bogus.DataSets;
using FluentAssertions;
using Xunit;

namespace Bogus.Tests.DataSetTests 
{
   public class PhoneNumbersTest : SeededTest 
   {
      public PhoneNumbersTest() 
      {
         phone = new PhoneNumbers();
      }

      private readonly PhoneNumbers phone;

      [Fact]
      public void can_get_phone_number() 
      {
         phone.PhoneNumber()
            .Should().Be("260-860-6439 x1750");
      }

      [Fact]
      public void can_get_phone_number_of_specific_format() 
      {
         phone.PhoneNumber("## ### ####")
            .Should().Be("61 860 6064");
      }

      [Fact]
      public void can_get_phone_number_via_formats_index() 
      {
         phone.PhoneNumberFormat(1)
            .Should().Be("(686) 206-0643");
      }

      [Fact]
      public void can_use_local_seed_for_person() 
      {
         var seededPhone = new PhoneNumbers(seed: 3);
         seededPhone.PhoneNumber("## ### ####")
            .Should().Be("26 815 1293");

         var seededPhone42 = new PhoneNumbers(seed: 42);
         seededPhone42.PhoneNumber("## ### ####")
            .Should().Be("61 151 2751");
      }
   }
}