Massa de dados gerada a partir do website: json-generator.com

script:
[
  '{{repeat(20000)}}',
  {
    tradeId: '{{index(1)}}',
    tradeDate: '{{date( new Date(2020, 9, 20, 10, 0), new Date(2020, 9, 20, 17, 0), "YYYY-MM-dd HH:mm")}}',
    side: '{{random("C", "V")}}',
    ticker: '{{random("PETR4", "ITUB4", "BBDC4", "VVAR3", "MGLU3")}}',
    quantity: '{{integer(10, 3000)}}',
    price: '{{floating(20, 30, 2, "0,0.00")}}',
    account: '{{random(1528, 4320, 7579)}}'
  }
]