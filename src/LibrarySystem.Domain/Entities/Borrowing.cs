using LibrarySystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Domain.Entities
{
    public class Borrowing
    {
        public  Guid Id { get; private set; } = Guid.NewGuid();
        public Guid BookId { get; private set; }
        public Guid MemberId { get; private set; }
        public DateTime BorrowDate { get; private set; } = DateTime.UtcNow;
        public DateTime DueDate { get; private set; } 
        public DateTime? ReturnDate { get; private set; } = null ;
        public BorrowingStatus Status { get; private set; } = BorrowingStatus.Borrowed;
        public decimal LateFee { get; private set; } = 0;

        public Borrowing(Guid bookId , Guid memberId)
        {
            if(bookId == Guid.Empty)
                throw new ArgumentException("Book Id cannot be empty.", nameof(bookId));

            if(memberId == Guid.Empty)
                throw new ArgumentException("Member Id cannot be empty.", nameof(memberId));

            BookId = bookId;
            MemberId = memberId;
            DueDate = BorrowDate.AddDays(14);

        }
        public void Return( )
        {
            if(Status != BorrowingStatus.Borrowed) 
                throw new InvalidOperationException("Only borrowed books can be returned.");
            ReturnDate = DateTime.UtcNow;
            if(ReturnDate > DueDate)
            {
                TimeSpan delay = ReturnDate.Value - DueDate;
                int overdueDays = (int)delay.TotalDays;

                Status = BorrowingStatus.Overdue;
                LateFee = overdueDays * 5m;
            }
            else
            {
                Status = BorrowingStatus.Returned;
            }
        }



    }
}
