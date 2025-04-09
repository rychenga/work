# PairCids

## POST: /api/mat/v1/wms/PairCids
- 憑單明細查詢 API 

### Parameter fields

|Attribute|Type|Required|Description|
|---|---|---|---|
|OVC_START_DATE_TIME|Day|Y|開始時間, EXP: 2025/01/01 00:00:00|
|OVC_END_DATE_TIME|Day|Y|結束時間, EXP: 2025/01/02 00:00:00|
|PairType|String|N|憑單, EXP: 只能是 2N3N或2C3C|

### Example Parameter
```json
{
  "OVC_START_DATE_TIME": "2025/01/01 00:00:00",
  "OVC_END_DATE_TIME": "2025/01/02 00:00:00",
  "PairType": "2N3N"
}
```

### Response fields

|Attribute|Type|Required|Description|
|---|---|---|---|
|OVC_CID|String|Y||
|OVC_DEPT_ID|String|Y||
|OVC_CTRL_UNIT|String|Y||
|OVC_JOB_CODE|String|N||
|:||||
|:||||
|Items|Array Object Items / Items[ ]|Y||

### Items fields

|Attribute|Type|Required|Description|
|---|---|---|---|
|OVC_CID|String|Y||
|ONB_ITEM_ON|Number|Y||
|ONB_ITEM_ID|Number|Y||
|ONB_PURCH_ON|String|N||
|:||||
|:||||
|OVC_UN_TYPE|String|Y||

### Example Response
```json
{
  "OVC_CID": "3C65001110825000035",
  "OVC_DEPT_ID": "6500",
  "OVC_CTRL_UNIT": "6514",
  "OVC_WH": "電子庫(221B)",
  "OVC_POJ_CODE": "VQCADS",
  "OVC_WBS_NO": "A140000700",
  "OVC_ANLY_CODE": "3110",
  "OVC_REQ_DATE": "2022/08/25",
  "OVC_LEDGER_CATE": "T",
  "OVC_MEMO": "系統自動調撥",
  "OVC_APPLY_ID": "1085399",
  "OVC_APPLY_DATE": "2022/08/25",
  "OVC_STATUS": "C02",
  "OVC_APV_DATE": "2022/08/25 13:58:23",
  "OVC_MINUS": "N",
  "OVC_JOB_CODE": null,
  "OVC_RM_DEM_NO": null,
  "OVC_PURCH": null,
  "OVC_PURCH_SUB": null,
  "ONB_SHIP_TIMES": null,
  "OVC_RCID": "2C65001110825000035",
  "OVC_RUSER_ID": "1085399",
  "OVC_RPOJ_CODE": "VQCADS",
  "OVC_RDEPT_ID": "6500",
  "OVC_RANLY_CODE": "3110",
  "OVC_3L_MEMO": null,
  "OVC_APPLY_NAME": "鍾穎琪",
  "OVC_RUSER_NAME": "鍾穎琪",
  "OVC_CREATE_NAME": "鍾穎琪",
  "OVC_DOC_ON": null,
  "OVC_LOGISTICS_KIND": null,
  "OVC_LOGISTICS_NAME": null,
  "OVC_LOGISTICS_ID": null,
  "OVC_LOGISTICS_PHON": null,
  "OVC_LOGISTICS_DATE": null,
  "OVC_LOGISTICS_WH": null,
  "OVC_LOGISTICS_MEMO": null,
  "Items": [
    {
      "OVC_CID": "3C65001110825000035",
      "ONB_ITEM_ON": 1,
      "ONB_ITEM_ID": 2108290048531,
      "ONB_INV_ID": 2201140114528,
      "ONB_RITEM_ON": 1,
      "ONB_PURCH_ON": null,
      "OVC_LOC": "A",
      "OVC_IN_STO_DATE": "200701080022212",
      "OVC_PROD_YEAR": "2006/05/29",
      "OVC_TEMP_PICK_NO": "0",
      "OVC_TMATST": "951206-6",
      "OVC_MRB": "合格",
      "OVC_BELONG": "-",
      "ONB_APPLY_QTY": 8,
      "ONB_APPLY_TOT": 8,
      "ONB_APV_QTY": 8,
      "ONB_APV_TOT": 1560,
      "OVC_PART_NO": "5905M55342E06B29D4R",
      "OVC_INTG_PIN": "5905YETT53633",
      "OVC_ITEM_CNAME": "電阻晶片",
      "OVC_SPEC": "029.40 Ω 1% 1/20W，規範說明欄：M55342E06B29D4R",
      "OVC_UN_TYPE": "EA"
    }
  ]
}
```
### Example ERROR Response Message
```json
{
    "error": "Invalid request body"
}
```

