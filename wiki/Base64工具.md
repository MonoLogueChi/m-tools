## Base64工具

### 路由

/api/base64

### 请求方式

- [x] GET
- [x] POST

### 参数

- type `encode` or `decode`
- raw 需要编码或解码的内容

### 示例

https://tool.sm9.top/api/base64?type=encode&raw=%E8%8D%89%E6%B3%A5%E9%A9%AC

https://tool.sm9.top/api/base64  
Json数据 {"type":"encode","rawdata":"艹"}  
Content-type: application/json; charset=utf-8

https://tool.sm9.top/api/base64/from  
数据表单 type=encode&raw=%E8%8D%89%E6%B3%A5%E9%A9%AC
Content-Type: application/x-www-form-urlencoded; charset=utf-8




### 计划

- [ ] 换行
- [ ] UrlEncode和UrlDecode选择
- [ ] 文件编码和解码支持