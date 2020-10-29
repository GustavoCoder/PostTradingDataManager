
1. Update all Nuget packages.
2. Get the file test_data.json located in the PostingTradingDataManager.Repository and place it in the c:\test\ folder. 
If you want to save it somewhere else, please change Web.config. Eg. <add key="testData" value="yourfolder\test_data.json" />
3. Set startup projects: PostTradingDataManager and PostTradingDataManager.UI.
4. Testing market data was generated from json-generator.com by the following script

{
"tradesCollection" :  
  ['{{repeat(20000)}}', {
    tradeId: '{{index(1)}}',
    tradeDate: '{{date( new Date(2020, 9, 23, 10, 0), new Date(2020, 9, 23, 17, 0), "YYYY-MM-dd HH:mm")}}',
    side: '{{random("C", "V")}}',
    ticker: '{{random("PETR4", "ITUB4", "BBDC4", "VVAR3", "MGLU3")}}',
    quantity: '{{random(100, 200, 300, 500, 1000, 2000)}}',
    price: '{{floating(20, 30, 2, "0,0.00")}}',
    account: '{{random(1528, 4320, 7579)}}'   
  }]
}