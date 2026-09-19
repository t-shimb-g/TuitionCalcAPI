# Tuition Calculator API
This is a C# API used for generating student data from a `.csv` to a `.pdf`.

## Sample Input
| Family    | Student    | Grade |   Member   |     Scholarship     | RaiseRight | Tuition Assistance | Miscellaneous |
| :-------- | :--------- | :---: |:----------:|:-------------------:| :--------: | :----------------: | :-----------: |
| Family A  | Student A1 |   8   |    Yes     |          —          |  $846.51   |         —          |       —       |
| Family C  | Student C1 |   5   |     No     |      $2,394.00      |  $211.78   |         —          |       —       |
| Family I  | Student I1 |   6   |    Yes     |          —          |   $7.31    |     $3,000.00      |       —       |
| Family Y  | Student Y1 |   7   |    Yes     |          —          |   $97.50   |     $2,596.00      |       —       |
| Family AE | Student AE1|   4   |     No     |          —          |  $204.60   |     $4,000.00      |       —       |
| Family AO | Student AO1|   7   |     No     |      $2,394.00      |     —      |         —          |       —       |

Above is a sample input for the `.csv` containing student tuition data. Sample spreadsheet can be found [here](https://github.com/t-shimb-g/TuitionCalcAPI/blob/main/TestSpreadsheet.csv).

## Calling API
### Health route
Simple `GET` route to check functionality

`http://tuitioncalc.runasp.net/health`

### Submit `.csv` route
A `POST` route that returns a processed `.pdf` file containing the `.csv` file data

`http://tuitioncalc.runasp.net/submitcsv`

## Sample Output
[Current PDF output](https://github.com/t-shimb-g/TuitionCalcAPI/blob/main/tuition.pdf)
[Eventual PDF output](https://github.com/t-shimb-g/TuitionCalcAPI/blob/main/TestSpreadsheet.pdf)


## TODO:
- Implement Google authentication to use API
- Format data into proper tuition statement
- React UI for user to submit the CSV