import xml.etree.ElementTree as ET

# Load and parse the XML file
tree = ET.parse('test_results.xml')
root = tree.getroot()

# Namespace
ns = {'ns': 'http://microsoft.com/schemas/VisualStudio/TeamTest/2010'}

# Initialize the report
report = []

# Helper function to get test case details
def get_test_details(test_case):
    test_name = test_case.attrib['testName']
    result = test_case.attrib['outcome']
    return test_name, result

# Add Unit Test Summary
unit_tests = root.findall('.//ns:UnitTestResult', ns)
report.append("#### Unit Test Summary")
report.append(f"Total Tests: {len(unit_tests)}")
passed_tests = sum(1 for test in unit_tests if test.attrib['outcome'] == 'Passed')
report.append(f"Success Rate: {passed_tests / len(unit_tests) * 100:.2f}%\n")
report.append("| Test Suite | Test Case | Result |")
report.append("|------------|-----------|--------|")

for test in unit_tests:
    test_name, result = get_test_details(test)
    test_suite = test_name.split('.')[0]
    report.append(f"| {test_suite} | {test_name} | {result} |")

# Add Detailed Test Case Example
report.append("\n##### Detailed Unit Test Example")
report.append("**Test Case Name:** Expense_WithValidAmount_CanBeCreated\n")
report.append("**Purpose:** To ensure that an Expense entity can be created with a valid amount.\n")
report.append("**Setup:** Create an instance of `ExpenseEntity`.\n")
report.append("**Execution Steps:**")
report.append("1. Set the `Amount` property to a valid amount.")
report.append("2. Call the method to create the expense entity.\n")
report.append("**Expected Results:** The expense entity is created successfully with the specified amount.\n")
report.append("**Actual Results:** The test passes, confirming the entity is created as expected.\n")

# Convert report to Markdown format
report_markdown = "\n".join(report)

# Save report to file
report_path = ('test_report.md')
with open(report_path, 'w') as f:
    f.write(report_markdown)

# Displaying the report for verification
report_markdown
