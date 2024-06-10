#### Unit Test Summary
Total Tests: 80
Success Rate: 100.00%

| Test Suite | Test Case | Result |
|------------|-----------|--------|
| IntegrationTests | IntegrationTests.Invoice.Sale.RegisterSaleTests.AddSale_WhenItemDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemName_WithAdminToken_Succeeds(itemName: "hamiNepaliHamroNepal") | Passed |
| IntegrationTests | IntegrationTests.Item.stock.ReduceStockTests.ReduceStock_WhenItemDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Income.IncomeTests.RegisterIncome_WithValidRequest_Succeeds | Passed |
| IntegrationTests | IntegrationTests.Item.UpdateItemTests.UpdateItem_ValidItemName_WithAdminToken_Succeeds | Passed |
| IntegrationTests | IntegrationTests.BillingParty.CreateTests.CreateBillingParty_ValidBillingParty_AlreadyExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Income.GetIncomeByBillingPartyTests.GetIncomeByBillingParty_NoBillingParty_ReturnsAnEmptyList | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemNameThatAlreadyExists_WithAdminToken_Fails(itemName: "thr") | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_InValidItemName_WithAdminToken_Fails(itemName: "aaaaaaaaaaaaaaaaaaaaa") | Passed |
| IntegrationTests | IntegrationTests.Income.IncomeTests.RegisterIncome_WhenBillingPartyDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.BillingParty.GetBillingPartyTests.GetBillingParties_NoBillingParty_ReturnsAnEmptyList | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemNameThatAlreadyExists_WithAdminToken_Fails(itemName: "gatta") | Passed |
| IntegrationTests | IntegrationTests.Item.stock.AddStockTests.AddStock_WhenItemDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.stock.GetStocksTests.GetStocks_NoTokenFails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_InValidItemName_WithAdminToken_Fails(itemName: "hami Nepali Hamro Nepal") | Passed |
| IntegrationTests | IntegrationTests.Authentication.LoginAdminTests.LoginAdmin_WithValidEmailAnd_InValidPassword_ReturnsBadRequestResponse_WithCorrectErrorMessage | Passed |
| IntegrationTests | IntegrationTests.Expense.ExpenseTests.RegisterExpense_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemName_WithAdminToken_Succeeds(itemName: "someitem name12") | Passed |
| IntegrationTests | IntegrationTests.BillingParty.GetBillingPartyTests.GetBillingParty_BillingPartyExistsInDatabase_ReturnsListOfBillingParties | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemNameThatAlreadyExists_WithAdminToken_Fails(itemName: "someitem name12") | Passed |
| IntegrationTests | IntegrationTests.Item.stock.ReduceStockTests.RemoveStock_NoTokenFails | Passed |
| IntegrationTests | IntegrationTests.BillingParty.UpdateBillingPartyCommandTests.UpdateBillingParty_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Purchase.RegisterPurchaseTests.AddPurchase_WhenBillingPartyDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.UpdateItemTests.UpdateItem_ItemNameAlreadyExists_WithAdminToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.UpdateItemTests.UpdateItem_ItemDoesNotExist_WithAdminToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.UpdateItemTests.UpdateItem_InvalidGUID_WithAdminToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.stock.AddStockTests.AddStock_WhenItemExists_AddsStock | Passed |
| IntegrationTests | IntegrationTests.Invoice.Sale.RegisterSaleTests.AddSale_NoTokenFails | Passed |
| IntegrationTests | IntegrationTests.Item.UpdateItemTests.UpdateItem_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.stock.GetStocksTests.GetStocks_WhenItemExists_AndStocksDoesNotExists_ReturnsSuccessWithEmptyList | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_InValidItemName_WithAdminToken_Fails(itemName: "") | Passed |
| IntegrationTests | IntegrationTests.Authentication.RegisterAdminTests.RegisterAdmin_WithAdminToken_InvalidEmail_Fails | Passed |
| IntegrationTests | IntegrationTests.BillingParty.UpdateBillingPartyCommandTests.UpdateBillingParty_ValidBillingParty_PartyDoesNotExist_Fails | Passed |
| IntegrationTests | IntegrationTests.BillingParty.CreateTests.CreateBillingParty_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Income.GetIncomeByBillingPartyTests.GetIncomeByBillingParty_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Purchase.RegisterPurchaseTests.AddPurchase_WhenItemDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Expense.ExpenseTests.RegisterExpense_WithValidEmployeeRequest_Succeeds | Passed |
| IntegrationTests | IntegrationTests.BillingParty.UpdateBillingPartyCommandTests.UpdateBillingParty_ValidBillingParty_PartyExists_Succeeds | Passed |
| IntegrationTests | IntegrationTests.Item.stock.GetStocksTests.GetStocks_WhenItemExists_AndStocksAlsoExists_ReturnsSuccessWithNonEmptyList | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemName_WithAdminToken_Succeeds(itemName: "gatta") | Passed |
| IntegrationTests | IntegrationTests.Item.GetItemTests.GetItems_NoItems_ReturnsAnEmptyList | Passed |
| IntegrationTests | IntegrationTests.Purchase.RegisterPurchaseTests.AddPurchase_WhenItemAndBillingPartyExists_AddPurchase | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemNameThatAlreadyExists_WithAdminToken_Fails(itemName: "GATTA") | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemName_WithAdminToken_Succeeds(itemName: "someitem name") | Passed |
| IntegrationTests | IntegrationTests.Income.IncomeTests.RegisterIncome_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.GetItemTests.GetItems_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Authentication.RegisterAdminTests.Register_AdminWithAdminToken_WhenAdminAlreadyExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemNameThatAlreadyExists_WithAdminToken_Fails(itemName: "hamiNepaliHamroNepal") | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_InValidItemName_WithAdminToken_Fails(itemName: "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa") | Passed |
| IntegrationTests | IntegrationTests.Purchase.RegisterPurchaseTests.AddPurchase_NoTokenFails | Passed |
| IntegrationTests | IntegrationTests.Invoice.Sale.RegisterSaleTests.AddSale_WhenItemAndBillingPartyExists_AddSale | Passed |
| IntegrationTests | IntegrationTests.Item.stock.AddStockTests.AddStock_NoTokenFails | Passed |
| IntegrationTests | IntegrationTests.Expense.ExpenseTests.RegisterExpense_WhenBillingPartyDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemName_WithAdminToken_Succeeds(itemName: "GATTA") | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemName_WithAdminToken_Succeeds(itemName: "aaaaaaaaaaaaaaaaaaaa") | Passed |
| IntegrationTests | IntegrationTests.Authentication.RegisterAdminTests.RegisterAdmin_WithEmployeeToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Authentication.LoginAdminTests.LoginAdmin_WithInValidEmailAnd_InValidPassword_ReturnsBadRequestResponse_WithCorrectErrorMessage | Passed |
| IntegrationTests | IntegrationTests.Item.GetItemTests.GetItem_ItemExistsInDatabase_ReturnsListOfItems | Passed |
| IntegrationTests | IntegrationTests.BillingParty.CreateTests.CreateBillingParty_InvalidBillingParty_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.stock.GetStocksTests.GetStocks_WhenItemDoesNotExist_ReturnsEmptyList | Passed |
| IntegrationTests | IntegrationTests.Item.stock.ReduceStockTests.Reduce_WhenItemExists_ReducesStock | Passed |
| IntegrationTests | IntegrationTests.Income.GetIncomeByBillingPartyTests.GetIncomeByBillingParty_BillingPartyExistsInDatabase_HasNoIncome_ReturnsAnEmptyList | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Expense.ExpenseTests.RegisterExpense_WhenEmployeeDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemNameThatAlreadyExists_WithAdminToken_Fails(itemName: "aaaaaaaaaaaaaaaaaaaa") | Passed |
| IntegrationTests | IntegrationTests.Invoice.Sale.RegisterSaleTests.AddSale_WhenBillingPartyDoesNotExists_Fails | Passed |
| IntegrationTests | IntegrationTests.Authentication.RegisterAdminTests.RegisterAdmin_WithAdminToken_InvalidPassword_LessThan5Chars_Fails | Passed |
| IntegrationTests | IntegrationTests.Authentication.LoginAdminTests.LoginAdmin_WithValidEmailAndValidPassword_ReturnsJwtTokenAndOkResponse | Passed |
| IntegrationTests | IntegrationTests.Authentication.RegisterAdminTests.RegisterAdmin_WithAdminToken_Succeeds | Passed |
| IntegrationTests | IntegrationTests.Item.stock.ReduceStockTests.ReduceStock_WhenStockIsLessThanWeight_Fails | Passed |
| IntegrationTests | IntegrationTests.Income.GetIncomeByBillingPartyTests.GetIncomeByBillingParty_BillingPartyExistsInTheDatabase_AndHasIncome_ReturnsTheIncomeLists | Passed |
| IntegrationTests | IntegrationTests.Expense.ExpenseTests.RegisterExpense_WithInvalidCategoryRequest_Fails | Passed |
| IntegrationTests | IntegrationTests.Authentication.RegisterAdminTests.RegisterAdmin_WithNoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Expense.ExpenseTests.RegisterExpense_WithValidBillingPartyRequest_Succeeds | Passed |
| IntegrationTests | IntegrationTests.Authentication.RegisterAdminTests.RegisterAdmin_WithAdminToken_InvalidPassword_NotLetterAndNumber_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemName_WithAdminToken_Succeeds(itemName: "thr") | Passed |
| IntegrationTests | IntegrationTests.BillingParty.GetBillingPartyTests.GetBillingParties_NoToken_Fails | Passed |
| IntegrationTests | IntegrationTests.Item.CreateItemTests.CreateItem_ValidItemNameThatAlreadyExists_WithAdminToken_Fails(itemName: "someitem name") | Passed |
| IntegrationTests | IntegrationTests.BillingParty.CreateTests.CreateBillingParty_ValidBillingParty_Succeeds | Passed |
| IntegrationTests | IntegrationTests.Expense.ExpenseTests.RegisterExpense_WithValidCategoryRequest_Succeeds | Passed |

##### Detailed Unit Test Example
**Test Case Name:** Expense_WithValidAmount_CanBeCreated

**Purpose:** To ensure that an Expense entity can be created with a valid amount.

**Setup:** Create an instance of `ExpenseEntity`.

**Execution Steps:**
1. Set the `Amount` property to a valid amount.
2. Call the method to create the expense entity.

**Expected Results:** The expense entity is created successfully with the specified amount.

**Actual Results:** The test passes, confirming the entity is created as expected.
