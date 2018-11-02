using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using NhatVe.Models;

namespace NhatVe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // example 1
            //HtmlWeb htmlWeb = new HtmlWeb()
            //{
            //    AutoDetectEncoding = false,
            //    OverrideEncoding = Encoding.UTF8  //Set UTF8 để hiển thị tiếng Việt
            //};

            ////Load trang web, nạp html vào document
            //HtmlDocument document = htmlWeb.Load("http://www.webtretho.com/forum/f26/");

            ////Load các tag li trong tag ul
            //var threadItems = document.DocumentNode.SelectNodes("//ul[@id=\"threads\"]/li").ToList();

            //var items = new List<object>();
            //foreach (var item in threadItems)
            //{
            //    //Extract các giá trị từ các tag con của tag li
            //    var linkNode = item.SelectSingleNode(".//a[contains(@class,'title')]");
            //    var link = linkNode.Attributes["href"].Value;
            //    var text = linkNode.InnerText;
            //    var readCount = item.SelectSingleNode(".//div[@class='folTypPost']/ul/li/b").InnerText;

            //    items.Add(new { text, readCount, link });
            //}

            // example 2
            var html = @"
	<div id='rows_content_depart'>
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921102' departprice='1200000' departairline='departVN'
↵			departtime='depart1' departcode='VN-209' departtimefrom = '0600'
↵			departtimeto='0810' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921102'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921102'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921102'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921102' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-209</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921102' class='flight-code'>06:00</span> - <span class='flight-code'>08:10</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921102'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921102' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921102','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921102' flight-id='921102' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921102' id='select_depart_921102' name='select_depart' style='display: none;' onclick='select_flight('921102','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921102' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921102' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921102' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921102' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>06:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-209</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>08:10</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921102' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921103' departprice='1200000' departairline='departVN'
↵			departtime='depart1' departcode='VN-211' departtimefrom = '0630'
↵			departtimeto='0840' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921103'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921103'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921103'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921103' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-211</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921103' class='flight-code'>06:30</span> - <span class='flight-code'>08:40</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921103'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921103' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921103','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921103' flight-id='921103' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921103' id='select_depart_921103' name='select_depart' style='display: none;' onclick='select_flight('921103','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921103' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921103' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921103' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921103' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>06:30</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-211</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>08:40</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921103' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921104' departprice='1200000' departairline='departVN'
↵			departtime='depart1' departcode='VN-217' departtimefrom = '0700'
↵			departtimeto='0910' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921104'
↵			departis_ticket_promo='0'
↵			departseat='6'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921104'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921104'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921104' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-217</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921104' class='flight-code'>07:00</span> - <span class='flight-code'>09:10</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921104'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵											<div class='flight-seat margin-bottom-5 hidden-xs'>
↵							Chỉ còn 6 vé						</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921104' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921104','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921104' flight-id='921104' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921104' id='select_depart_921104' name='select_depart' style='display: none;' onclick='select_flight('921104','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921104' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921104' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921104' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921104' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>07:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-217</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>09:10</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921104' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921110' departprice='1200000' departairline='departVN'
↵			departtime='depart2' departcode='VN-233' departtimefrom = '1200'
↵			departtimeto='1415' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921110'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921110'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921110'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921110' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-233</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921110' class='flight-code'>12:00</span> - <span class='flight-code'>14:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921110'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921110' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921110','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921110' flight-id='921110' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921110' id='select_depart_921110' name='select_depart' style='display: none;' onclick='select_flight('921110','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921110' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921110' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921110' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921110' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>12:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-233</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>14:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921110' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921112' departprice='1200000' departairline='departVN'
↵			departtime='depart2' departcode='VN-239' departtimefrom = '1400'
↵			departtimeto='1615' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921112'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921112'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921112'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921112' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-239</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921112' class='flight-code'>14:00</span> - <span class='flight-code'>16:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921112'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921112' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921112','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921112' flight-id='921112' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921112' id='select_depart_921112' name='select_depart' style='display: none;' onclick='select_flight('921112','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921112' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921112' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921112' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921112' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>14:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-239</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>16:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921112' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921113' departprice='1200000' departairline='departVN'
↵			departtime='depart2' departcode='VN-243' departtimefrom = '1430'
↵			departtimeto='1645' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921113'
↵			departis_ticket_promo='0'
↵			departseat='5'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921113'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921113'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921113' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-243</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921113' class='flight-code'>14:30</span> - <span class='flight-code'>16:45</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921113'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵											<div class='flight-seat margin-bottom-5 hidden-xs'>
↵							Chỉ còn 5 vé						</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921113' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921113','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921113' flight-id='921113' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921113' id='select_depart_921113' name='select_depart' style='display: none;' onclick='select_flight('921113','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921113' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921113' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921113' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921113' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>14:30</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-243</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>16:45</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921113' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921114' departprice='1200000' departairline='departVN'
↵			departtime='depart2' departcode='VN-247' departtimefrom = '1500'
↵			departtimeto='1715' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921114'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921114'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921114'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921114' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-247</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921114' class='flight-code'>15:00</span> - <span class='flight-code'>17:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921114'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921114' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921114','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921114' flight-id='921114' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921114' id='select_depart_921114' name='select_depart' style='display: none;' onclick='select_flight('921114','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921114' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921114' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921114' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921114' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>15:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-247</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>17:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921114' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921115' departprice='1200000' departairline='departVN'
↵			departtime='depart2' departcode='VN-249' departtimefrom = '1530'
↵			departtimeto='1745' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921115'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921115'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921115'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921115' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-249</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921115' class='flight-code'>15:30</span> - <span class='flight-code'>17:45</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921115'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921115' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921115','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921115' flight-id='921115' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921115' id='select_depart_921115' name='select_depart' style='display: none;' onclick='select_flight('921115','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921115' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921115' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921115' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921115' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>15:30</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-249</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>17:45</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921115' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921119' departprice='1200000' departairline='departVN'
↵			departtime='depart2' departcode='VN-257' departtimefrom = '1630'
↵			departtimeto='1845' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921119'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921119'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921119'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921119' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-257</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921119' class='flight-code'>16:30</span> - <span class='flight-code'>18:45</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921119'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921119' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921119','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921119' flight-id='921119' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921119' id='select_depart_921119' name='select_depart' style='display: none;' onclick='select_flight('921119','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921119' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921119' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921119' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921119' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>16:30</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-257</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>18:45</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921119' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921121' departprice='1200000' departairline='departVN'
↵			departtime='depart2' departcode='VN-259' departtimefrom = '1700'
↵			departtimeto='1915' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921121'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921121'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921121'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921121' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-259</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921121' class='flight-code'>17:00</span> - <span class='flight-code'>19:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921121'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921121' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921121','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921121' flight-id='921121' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921121' id='select_depart_921121' name='select_depart' style='display: none;' onclick='select_flight('921121','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921121' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921121' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921121' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921121' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>17:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-259</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>19:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921121' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921122' departprice='1200000' departairline='departVN'
↵			departtime='depart3' departcode='VN-263' departtimefrom = '1800'
↵			departtimeto='2015' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921122'
↵			departis_ticket_promo='0'
↵			departseat='4'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921122'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921122'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921122' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-263</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921122' class='flight-code'>18:00</span> - <span class='flight-code'>20:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921122'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵											<div class='flight-seat margin-bottom-5 hidden-xs'>
↵							Chỉ còn 4 vé						</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921122' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921122','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921122' flight-id='921122' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921122' id='select_depart_921122' name='select_depart' style='display: none;' onclick='select_flight('921122','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921122' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921122' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921122' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921122' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>18:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-263</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>20:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921122' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921125' departprice='1200000' departairline='departVN'
↵			departtime='depart3' departcode='VN-285' departtimefrom = '2100'
↵			departtimeto='2310' departflightclass='E' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921125'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1200000' departpricechd='0' departpriceinf='0' departpricetotal='3120000'
↵				departpriceadttax='390000' departpricechdtax='0' departpriceinftax='0' departpricetax='720000'
↵			>
↵
↵			<div class='row' id='flight_content_921125'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921125'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921125' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-285</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921125' class='flight-code'>21:00</span> - <span class='flight-code'>23:10</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921125'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.200.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921125' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921125','E','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921125' flight-id='921125' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921125' id='select_depart_921125' name='select_depart' style='display: none;' onclick='select_flight('921125','depart','E','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921125' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921125' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921125' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921125' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1200000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1200000' id='data_price_adt'><span>1.200.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='490000' id='data_price_fee'><span>490.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='1690000'><span>1.690.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>21:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-285</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>23:10</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921125' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921105' departprice='1650000' departairline='departVN'
↵			departtime='depart1' departcode='VN-223' departtimefrom = '0800'
↵			departtimeto='1010' departflightclass='T' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921105'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1650000' departpricechd='0' departpriceinf='0' departpricetotal='4110000'
↵				departpriceadttax='435000' departpricechdtax='0' departpriceinftax='0' departpricetax='810000'
↵			>
↵
↵			<div class='row' id='flight_content_921105'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921105'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921105' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-223</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921105' class='flight-code'>08:00</span> - <span class='flight-code'>10:10</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921105'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.650.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921105' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921105','T','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921105' flight-id='921105' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921105' id='select_depart_921105' name='select_depart' style='display: none;' onclick='select_flight('921105','depart','T','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921105' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921105' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921105' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921105' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1650000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1650000' id='data_price_adt'><span>1.650.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='535000' id='data_price_fee'><span>535.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='2185000'><span>2.185.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>08:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-223</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>10:10</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921105' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921107' departprice='1650000' departairline='departVN'
↵			departtime='depart1' departcode='VN-227' departtimefrom = '1000'
↵			departtimeto='1210' departflightclass='T' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921107'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1650000' departpricechd='0' departpriceinf='0' departpricetotal='4110000'
↵				departpriceadttax='435000' departpricechdtax='0' departpriceinftax='0' departpricetax='810000'
↵			>
↵
↵			<div class='row' id='flight_content_921107'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921107'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921107' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-227</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921107' class='flight-code'>10:00</span> - <span class='flight-code'>12:10</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921107'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.650.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921107' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921107','T','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921107' flight-id='921107' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921107' id='select_depart_921107' name='select_depart' style='display: none;' onclick='select_flight('921107','depart','T','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921107' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921107' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921107' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921107' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1650000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1650000' id='data_price_adt'><span>1.650.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='535000' id='data_price_fee'><span>535.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='2185000'><span>2.185.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>10:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-227</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>12:10</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921107' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921109' departprice='1650000' departairline='departVN'
↵			departtime='depart1' departcode='VN-231' departtimefrom = '1100'
↵			departtimeto='1315' departflightclass='T' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921109'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1650000' departpricechd='0' departpriceinf='0' departpricetotal='4110000'
↵				departpriceadttax='435000' departpricechdtax='0' departpriceinftax='0' departpricetax='810000'
↵			>
↵
↵			<div class='row' id='flight_content_921109'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921109'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921109' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-231</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921109' class='flight-code'>11:00</span> - <span class='flight-code'>13:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921109'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.650.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921109' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921109','T','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921109' flight-id='921109' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921109' id='select_depart_921109' name='select_depart' style='display: none;' onclick='select_flight('921109','depart','T','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921109' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921109' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921109' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921109' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1650000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1650000' id='data_price_adt'><span>1.650.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='535000' id='data_price_fee'><span>535.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='2185000'><span>2.185.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>11:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-231</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>13:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921109' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921123' departprice='1650000' departairline='departVN'
↵			departtime='depart3' departcode='VN-269' departtimefrom = '1900'
↵			departtimeto='2115' departflightclass='T' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921123'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1650000' departpricechd='0' departpriceinf='0' departpricetotal='4110000'
↵				departpriceadttax='435000' departpricechdtax='0' departpriceinftax='0' departpricetax='810000'
↵			>
↵
↵			<div class='row' id='flight_content_921123'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921123'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921123' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-269</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921123' class='flight-code'>19:00</span> - <span class='flight-code'>21:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921123'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.650.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921123' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921123','T','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921123' flight-id='921123' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921123' id='select_depart_921123' name='select_depart' style='display: none;' onclick='select_flight('921123','depart','T','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921123' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921123' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921123' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921123' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1650000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1650000' id='data_price_adt'><span>1.650.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='535000' id='data_price_fee'><span>535.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='2185000'><span>2.185.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>19:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-269</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>21:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921123' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921124' departprice='1650000' departairline='departVN'
↵			departtime='depart3' departcode='VN-279' departtimefrom = '2000'
↵			departtimeto='2215' departflightclass='T' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921124'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='1650000' departpricechd='0' departpriceinf='0' departpricetotal='4110000'
↵				departpriceadttax='435000' departpricechdtax='0' departpriceinftax='0' departpricetax='810000'
↵			>
↵
↵			<div class='row' id='flight_content_921124'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921124'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921124' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-279</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921124' class='flight-code'>20:00</span> - <span class='flight-code'>22:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921124'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>1.650.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921124' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921124','T','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921124' flight-id='921124' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921124' id='select_depart_921124' name='select_depart' style='display: none;' onclick='select_flight('921124','depart','T','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921124' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921124' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921124' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921124' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='1650000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='1650000' id='data_price_adt'><span>1.650.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='535000' id='data_price_fee'><span>535.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='2185000'><span>2.185.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>20:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-279</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>22:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921124' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921108' departprice='2850000' departairline='departVN'
↵			departtime='depart1' departcode='VN-229' departtimefrom = '1030'
↵			departtimeto='1240' departflightclass='K' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921108'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='2850000' departpricechd='0' departpriceinf='0' departpricetotal='6750000'
↵				departpriceadttax='555000' departpricechdtax='0' departpriceinftax='0' departpricetax='1050000'
↵			>
↵
↵			<div class='row' id='flight_content_921108'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921108'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921108' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-229</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921108' class='flight-code'>10:30</span> - <span class='flight-code'>12:40</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921108'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>2.850.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921108' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921108','K','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921108' flight-id='921108' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921108' id='select_depart_921108' name='select_depart' style='display: none;' onclick='select_flight('921108','depart','K','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921108' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921108' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921108' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921108' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='2850000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='2850000' id='data_price_adt'><span>2.850.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='655000' id='data_price_fee'><span>655.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='3505000'><span>3.505.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>10:30</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-229</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>12:40</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921108' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921111' departprice='2850000' departairline='departVN'
↵			departtime='depart2' departcode='VN-237' departtimefrom = '1300'
↵			departtimeto='1515' departflightclass='K' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921111'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='2850000' departpricechd='0' departpriceinf='0' departpricetotal='6750000'
↵				departpriceadttax='555000' departpricechdtax='0' departpriceinftax='0' departpricetax='1050000'
↵			>
↵
↵			<div class='row' id='flight_content_921111'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921111'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921111' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-237</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921111' class='flight-code'>13:00</span> - <span class='flight-code'>15:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921111'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>2.850.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921111' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921111','K','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921111' flight-id='921111' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921111' id='select_depart_921111' name='select_depart' style='display: none;' onclick='select_flight('921111','depart','K','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921111' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921111' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921111' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921111' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='2850000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='2850000' id='data_price_adt'><span>2.850.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='655000' id='data_price_fee'><span>655.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='3505000'><span>3.505.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>13:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-237</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>15:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921111' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921117' departprice='2850000' departairline='departVN'
↵			departtime='depart2' departcode='VN-253' departtimefrom = '1600'
↵			departtimeto='1815' departflightclass='K' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921117'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='2850000' departpricechd='0' departpriceinf='0' departpricetotal='6750000'
↵				departpriceadttax='555000' departpricechdtax='0' departpriceinftax='0' departpricetax='1050000'
↵			>
↵
↵			<div class='row' id='flight_content_921117'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921117'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921117' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-253</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921117' class='flight-code'>16:00</span> - <span class='flight-code'>18:15</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921117'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>2.850.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921117' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921117','K','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921117' flight-id='921117' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921117' id='select_depart_921117' name='select_depart' style='display: none;' onclick='select_flight('921117','depart','K','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921117' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921117' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921117' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921117' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='2850000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='2850000' id='data_price_adt'><span>2.850.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='655000' id='data_price_fee'><span>655.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='3505000'><span>3.505.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>16:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-253</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>18:15</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921117' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵		
↵			
↵		<div class='bpv-list-item clearfix' id='flight_row_921106' departprice='3150000' departairline='departVN'
↵			departtime='depart1' departcode='VN-225' departtimefrom = '0900'
↵			departtimeto='1110' departflightclass='M' departdayfrom='28' departmonthfrom='11'
↵			departdayto='28' departmonthto='11' departflightrclass='' departflightstop='0' departseg='921106'
↵			departis_ticket_promo='0'
↵			departseat='7'
↵			
↵                         departselected_value='66180998'
↵             departlast_update=''
↵                        				departdatefrom='28/11/2018'
↵				departdateto='28/11/2018'
↵				departpriceadt='3150000' departpricechd='0' departpriceinf='0' departpricetotal='7110000'
↵				departpriceadttax='435000' departpricechdtax='0' departpriceinftax='0' departpricetax='810000'
↵			>
↵
↵			<div class='row' id='flight_content_921106'>
↵								<div class='col-xs-3 text-left pd-right-0' style='width: 30%;'>
↵					<span id='airline_depart_921106'><span  class='flight-VN'></span></span>
↵					<span class='flight-name hidden-xs'>Vietnam Airlines</span>
↵				</div>
↵
↵				<div id='code_depart_921106' class='col-xs-1 col-code-fly pd-right-0' style='width: 20%;'>
↵					<span class='flight-code'>VN-225</span>
↵				</div>
↵
↵				<div class='col-xs-5 col-time-fly pd-right-0' style='width: 20%;'>
↵					<span id='time_depart_921106' class='flight-code'>09:00</span> - <span class='flight-code'>11:10</span>
↵					<br>
↵					<div style='display: none;'>
↵													Hà Nội (HAN) - Hồ Chí Minh (SGN) - <span id='router_depart_921106'>Thứ 4, 28/11/2018</span>
↵											</div>
↵				</div>
↵
↵
↵				<div class='col-xs-3 col-price-fly text-right' style='width: 30%;'>
↵					<div class='bpv-price-from'>
↵						<span>3.150.000đ</span>					</div>
↵					
↵				</div>
↵
↵			</div>
↵
↵			<div class='row margin-bottom-10'>
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-7 show-flight-detail'>
↵					<span class='show-detail'><a id='show_921106' href='javascript:show_flight_detail('AAFCB0E92712EC0F5C29A52CA18699321541151915', '15411518827b6bbdcd', '921106','M','0','depart', 'VN')'>[ + ] Chi tiết chuyến bay</a></span>
↵				</div>
↵
↵				<div class='col-lg-6 col-md-6 col-sm-6 col-xs-5 text-right show-flight-selected'>
↵					
↵					<label id='label_flight_select_921106' flight-id='921106' class='radio btn btn-border-blue flight-select'>
↵		          		<input type='radio' value='921106' id='select_depart_921106' name='select_depart' style='display: none;' onclick='select_flight('921106','depart','M','0', 'VN')'>
↵		          		<span id='icon_checked_depart_921106' style='display: none;' class='text-choice glyphicon glyphicon-ok'></span>
↵		          		<b>Chọn vé</b>
↵		          		<span class='hidden-xs'></span>
↵		          	</label>
↵				</div>
↵				<div id='text_note_selected_flight_921106' class='margin-top-5 col-xs-12 text-right' style='display: none;'>
↵			        		          		<span id='select_flight_next_921106' class='pull-right' style='display: none; font-size: 14px;'>
↵		          			<button class='btn btn-yellow visible-xs' onclick='go_position_id('#content_summary_flight')'>Click để xem&nbsp;tổng tiền&nbsp;<span class='glyphicon glyphicon-circle-arrow-down'> </span></button>
↵		          			<span class='hidden-xs'>Vui lòng chọn <b>Tiếp tục</b> <span class='glyphicon glyphicon-circle-arrow-right bpv-color-hot-deal'></span></span>
↵		          		</span>
↵									</div>
↵			</div>
↵			<div class='flight-details' data-search-ws='1' id='flight_detail_921106' loaded='0' style='display:none;' show='hide'>
↵				<div class='row flight-details-background'>
↵<div id='itinerary_ruler_flight'>
↵	<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4 pull-right'>
↵		<div class='flight-price'>		
↵						<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0' data-price-adt='3150000' >1 Người lớn:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-adt='3150000' id='data_price_adt'><span>3.150.000đ</span></div>
↵			</div>
↵			
↵									
↵						
↵						
↵			<div class='row margin-bottom-10'>	
↵				<div class='col-xs-6 pd-right-0'>Thuế & phí:</div>
↵				<div class='col-xs-6 price-value text-right' data-price-fee='535000' id='data_price_fee'><span>535.000đ</span></div>
↵			</div>
↵			
↵			<div style='border-top: 1px solid #c8c8c8;' class='margin-bottom-10'></div>
↵			<div class='row'>	
↵				<div class='col-xs-6 label-total text-right'>Tổng tiền:</div>
↵				<div class='col-xs-6 price-total pd-left-0 text-right text-price' id='data_price_total' data-price-total='3685000'><span>3.685.000đ</span></div>
↵			</div>
↵		</div>
↵	</div>
↵	<div class='col-xs-12 col-sm-8 col-md-8 col-lg-8 sep-line'>
↵		<h3 class='bpv-color-title ruler-itinerary-flight'>Lộ trình chuyến bay:</h3>
↵		<div class='clearfix ruler-itinerary-flight margin-bottom-20'>
↵			<div class='col-xs-6 pd-right-0 pd-left-0'>
↵												<div class='margin-bottom-5'>
↵					Từ: <b id='data_flight_from'>Hà Nội (HAN)</b>
↵				</div>
↵								<div class='margin-bottom-5'>
↵					<b id='data_flight_time_from'>09:00</b> <span id='data_flight_date_from'>28/11/2018</span> 
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_airline_code'>VN-225</b> 
↵				</div>
↵			</div>
↵			
↵			<div class='col-xs-6 pd-right-0'>
↵				<div class='margin-bottom-5'>
↵					Đến: <b id='data_flight_to'>Hồ Chí Minh (SGN)</b>
↵				</div>
↵				
↵				<div class='margin-bottom-5'>
↵					<b id='data_flight_time_to'>11:10</b> <span id='data_flight_date_to'>28/11/2018</span>
↵				</div>
↵			</div>
↵		</div>
↵		
↵		<div>
↵			<h3 class='margin-top-0 bpv-color-title'>Điều kiện vé:</h3>
↵			<div class='col-xs-12 padding-left-0 fare_rules_921106' id='data_flight_fare_rules'>			
↵				
↵			</div>
↵		</div>
↵	</div>
↵</div>
↵</div>			</div>
↵		</div>
↵
↵			</div>
↵
↵
";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            //var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='rows_content_depart']");
            var listAir = htmlDoc.DocumentNode.SelectNodes("//div[@id='rows_content_depart']/div[@class='bpv-list-item clearfix']").ToList();
            var items = new List<object>();
            foreach (var item in listAir)
            {
                var itemNode = item.SelectSingleNode("//div[@class='bpv-list-item clearfix']"); // đang sai chỗ này
                var id = itemNode.Attributes["id"].Value;
                var departprice = itemNode.Attributes["departprice"].Value;
                var departairline = itemNode.Attributes["departairline"].Value;
                var departtime = itemNode.Attributes["departtime"].Value;
                var departcode = itemNode.Attributes["departcode"].Value;
                var departtimefrom = itemNode.Attributes["departtimefrom"].Value;
                var departtimeto = itemNode.Attributes["departtimeto"].Value;
                var departflightclass = itemNode.Attributes["departflightclass"].Value;
                var departdayfrom = itemNode.Attributes["departdayfrom"].Value;
                var departmonthfrom = itemNode.Attributes["departmonthfrom"].Value;
                var departdayto = itemNode.Attributes["departdayto"].Value;
                var departmonthto = itemNode.Attributes["departmonthto"].Value;
                var departflightrclass = itemNode.Attributes["departflightrclass"].Value;
                var departflightstop = itemNode.Attributes["departflightstop"].Value;
                var departseg = itemNode.Attributes["departprice"].Value;
                var departis_ticket_promo = itemNode.Attributes["departis_ticket_promo"].Value;
                var departseat = itemNode.Attributes["departseat"].Value;
                var departselected_value = itemNode.Attributes["departselected_value"].Value;
                var departlast_update = itemNode.Attributes["departlast_update"].Value;
                var departdatefrom = itemNode.Attributes["departdatefrom"].Value;
                var departdateto = itemNode.Attributes["departdateto"].Value;
                var departpriceadt = itemNode.Attributes["departpriceadt"].Value;
                var departpricechd = itemNode.Attributes["departpricechd"].Value;
                var departpriceinf = itemNode.Attributes["departpriceinf"].Value;
                var departpricetotal = itemNode.Attributes["departpricetotal"].Value;
                var departpriceadttax = itemNode.Attributes["departpriceadttax"].Value;
                var departpricechdtax = itemNode.Attributes["departpricechdtax"].Value;
                var departpriceinftax = itemNode.Attributes["departpriceinftax"].Value;
                var departpricetax = itemNode.Attributes["departpricetax"].Value;

                items.Add(new { id,
                    departprice,
                    departairline,
                    departtime,
                    departcode,
                    departtimefrom,
                    departtimeto,
                    departflightclass,
                    departdayfrom,
                    departmonthfrom,
                    departdayto,
                    departmonthto,
                    departflightrclass,
                    departflightstop,
                    departseg,
                    departis_ticket_promo,
                    departseat,
                    departselected_value,
                    departlast_update,
                    departdatefrom,
                    departdateto,
                    departpriceadt,
                    departpricechd,
                    departpriceinf,
                    departpricetotal,
                    departpriceadttax,
                    departpricechdtax,
                    departpriceinftax,
                    departpricetax
                });
            }

            return View(items);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
