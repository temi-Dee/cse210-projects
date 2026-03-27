# Week 04 Foundation Programs Design

---

## Program 1: Abstraction with YouTube Videos

### What the program does
Tracks a list of YouTube videos. Each video has a title, author, and length.
Each video also has a list of comments. The program displays each video's info
and its comments.

### Classes

---

#### Class: Comment
Represents a single comment on a video.

| Member Variables     | Type   |
|----------------------|--------|
| _commenterName       | string |
| _text                | string |

| Methods                  | Returns |
|--------------------------|---------|
| Comment(name, text)      | —       |
| GetCommenterName()       | string  |
| GetText()                | string  |

---

#### Class: Video
Represents a YouTube video and owns a list of comments.

| Member Variables     | Type           |
|----------------------|----------------|
| _title               | string         |
| _author              | string         |
| _lengthSeconds       | int            |
| _comments            | List<Comment>  |

| Methods                        | Returns |
|--------------------------------|---------|
| Video(title, author, length)   | —       |
| AddComment(comment)            | void    |
| GetNumComments()               | int     |
| GetTitle()                     | string  |
| GetAuthor()                    | string  |
| GetLength()                    | int     |
| DisplayInfo()                  | void    |

---

### Program Flow

```
Main()
 │
 ├── Create Video objects (title, author, lengthSeconds)
 │
 ├── For each Video:
 │     └── AddComment(new Comment(name, text))  [add 3+ comments]
 │
 └── For each Video:
       └── video.DisplayInfo()
             ├── prints title, author, length, comment count
             └── prints each comment (name + text)
```

---

## Program 2: Encapsulation with Online Ordering

### What the program does
Manages online orders. Each order has a customer and a shipping address.
Each order contains multiple products. The program calculates the total price
and generates a packing label and shipping label for each order.

### Classes

---

#### Class: Address
Stores and validates a shipping address.

| Member Variables | Type   |
|------------------|--------|
| _streetAddress   | string |
| _city            | string |
| _stateOrProvince | string |
| _country         | string |

| Methods                                      | Returns |
|----------------------------------------------|---------|
| Address(street, city, state, country)        | —       |
| IsInUSA()                                    | bool    |
| GetFullAddress()                             | string  |

---

#### Class: Customer
Represents the person placing the order.

| Member Variables | Type    |
|------------------|---------|
| _name            | string  |
| _address         | Address |

| Methods                      | Returns |
|------------------------------|---------|
| Customer(name, address)      | —       |
| GetName()                    | string  |
| GetAddress()                 | Address |
| IsInUSA()                    | bool    |

---

#### Class: Product
Represents a single product in an order.

| Member Variables | Type   |
|------------------|--------|
| _name            | string |
| _productId       | string |
| _price           | double |
| _quantity        | int    |

| Methods                              | Returns |
|--------------------------------------|---------|
| Product(name, id, price, quantity)   | —       |
| GetName()                            | string  |
| GetProductId()                       | string  |
| GetTotalCost()                       | double  |

---

#### Class: Order
Owns a list of products and a customer. Calculates totals and generates labels.

| Member Variables | Type            |
|------------------|-----------------|
| _products        | List<Product>   |
| _customer        | Customer        |

| Methods                    | Returns |
|----------------------------|---------|
| Order(customer)            | —       |
| AddProduct(product)        | void    |
| GetTotalCost()             | double  | ← sum of products + shipping ($5 USA / $35 intl)
| GetPackingLabel()          | string  |
| GetShippingLabel()         | string  |
| DisplayOrderSummary()      | void    |

---

### Program Flow

```
Main()
 │
 ├── Create Address objects
 ├── Create Customer objects (name + address)
 ├── Create Order objects (customer)
 │     └── AddProduct(new Product(name, id, price, qty))  [add multiple]
 │
 └── For each Order:
       └── order.DisplayOrderSummary()
             ├── prints GetPackingLabel()   → product names + IDs
             ├── prints GetShippingLabel()  → customer name + address
             └── prints GetTotalCost()      → products total + shipping fee
```

---

### Shipping Fee Rule (inside Order.GetTotalCost)
- Customer is in USA  → add $5.00
- Customer is outside USA → add $35.00
