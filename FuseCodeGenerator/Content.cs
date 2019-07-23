using System;

namespace FuseCodeGenerator
{
    public static class Content
    {
        
        public static string WriteBaseModule(string fileAppName, string appName)
        {
            string s = "import { NgModule } from '@angular/core';\n" +
            "import { RouterModule, Routes } from '@angular/router';\n" +
            "import { MatButtonModule } from '@angular/material/button';\n" +
            "import { MatChipsModule } from '@angular/material/chips';\n" +
            "import { MatRippleModule } from '@angular/material/core';\n" +
            "import { MatExpansionModule } from '@angular/material/expansion';\n" +
            "import { MatFormFieldModule } from '@angular/material/form-field';\n" +
            "import { MatIconModule } from '@angular/material/icon';\n" +
            "import { MatInputModule } from '@angular/material/input';\n" +
            "import { MatPaginatorModule } from '@angular/material/paginator';\n" +
            "import { MatSelectModule } from '@angular/material/select';\n" +
            "import { MatSnackBarModule } from '@angular/material/snack-bar';\n" +
            "import { MatSortModule } from '@angular/material/sort';\n" +
            "import { MatTableModule } from '@angular/material/table';\n" +
            "import { MatTabsModule } from '@angular/material/tabs';\n" +
            "import { NgxChartsModule } from '@swimlane/ngx-charts';\n\n" +

            "import { AgmCoreModule } from '@agm/core';\n" +
            "import { FuseSharedModule } from '@fuse/shared.module';\n" +
            "import { FuseWidgetModule } from '@fuse/components/widget/widget.module';\n\n" +

            "import { ListComponent } from 'app/main/apps/{0}/list/list.component';\n" +
            "import { ListService } from 'app/main/apps/{0}/list/list.service';\n" +
            "import { ItemComponent } from 'app/main/apps/{0}/item/item.component';\n" +
            "import { ItemService } from 'app/main/apps/{0}/item/item.service';\n\n" +            

            "const routes: Routes = [\n" +
            "{\n" +
                "path: 'list',\n" +
                "component: ListComponent,\n" +
                "resolve:\n" +
                "{\n" +
                    "data: ListService\n" +
                "}\n" +
            "},\n" +
            "{\n" +
                "path: 'item/:id',\n" +
                "component: ItemComponent,\n" +
                "resolve:\n" +
                "{\n" +
                    "data: ItemService\n" +
                "}\n" +
            "},\n" +
            "{\n" +
                "path: 'item/:id/:handle',\n" +
                "component: ItemComponent,\n" +
                "resolve:\n" +
                "{\n" +
                    "data: ItemService\n" +
                "}\n" +
            "}];\n\n" +                    

            "@NgModule({\n" +
                "declarations: [\n" +
                    "ListComponent,\n" +
                    "ItemComponent,\n" +
                "],\n" +
                "imports: [\n" +
                    "RouterModule.forChild(routes),\n\n" +

                   "MatButtonModule,\n" +
                   "MatChipsModule,\n" +
                   "MatExpansionModule,\n" +
                   "MatFormFieldModule,\n" +
                   "MatIconModule,\n" +
                   "MatInputModule,\n" +
                   "MatPaginatorModule,\n" +
                   "MatRippleModule,\n" +
                   "MatSelectModule,\n" +
                   "MatSortModule,\n" +
                   "MatSnackBarModule,\n" +
                   "MatTableModule,\n" +
                   "MatTabsModule,\n\n" +

                    "NgxChartsModule,\n" +
                    "AgmCoreModule.forRoot({\n" +
                    "apiKey: 'AIzaSyD81ecsCj4yYpcXSLFcYU97PvRsE_X8Bx8'\n" +
                "}),\n\n" +

                "FuseSharedModule,\n" +
                "FuseWidgetModule\n" +
            "],\n" +
           "providers: [\n" +
               "ListService,\n" +
               "ItemService,\n" +
           "]\n" +

           "})\n" +
           "export class {1}Module\n" +
           "{\n" +
           "}";

            s = s.Replace("{0}", fileAppName);
            s = s.Replace("{1}", appName);

            return s;
        }

        public static string WriteItemComponentTS(string appName)
        {
            string s = "import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';\n" +
            "import { FormBuilder, FormGroup } from '@angular/forms';\n" +
            "import { Location } from '@angular/common';\n" +
            "import { MatSnackBar } from '@angular/material/snack-bar';\n" +
            "import { Subject } from 'rxjs';\n" +
            "import { takeUntil } from 'rxjs/operators';\n\n" +

            "import { fuseAnimations } from '@fuse/animations';\n" +
            "import { FuseUtils } from '@fuse/utils';\n\n" +

            "import { Product } from 'app/main/apps/e-commerce/product/product.model';\n" +
            "import { EcommerceProductService } from 'app/main/apps/e-commerce/product/product.service';\n\n" +

            "@Component({\n" +
                "selector: 'e-commerce-product',\n" +
                "templateUrl: './product.component.html',\n" +
                "styleUrls: ['./product.component.scss'],\n" +
                "encapsulation: ViewEncapsulation.None,\n" +
                "animations: fuseAnimations\n" +
            "})\n" +
            "export class EcommerceProductComponent implements OnInit, OnDestroy\n" +
            "{\n" +
                "product: Product;\n" +
                "pageType: string;\n" +
                "productForm: FormGroup;\n\n" +

                "// Private\n" +
                "private _unsubscribeAll: Subject<any>;\n\n" + 

                "/**\n" +
                "* Constructor\n" +
                "*\n" +
                "* @param {EcommerceProductService} _ecommerceProductService\n" +
                "* @param {FormBuilder} _formBuilder\n" +
                "* @param {Location} _location\n" +
                "* @param {MatSnackBar} _matSnackBar\n" +
                "*/\n" +
                "constructor(\n" +
                    "private _ecommerceProductService: EcommerceProductService,\n" +
                    "private _formBuilder: FormBuilder,\n" +
                    "private _location: Location,\n" +
                    "private _matSnackBar: MatSnackBar\n" +
                ")\n\n" +
                "{\n" +
                    "// Set the default\n" +
                    "this.product = new Product();\n\n" +

                    "// Set the private defaults\n" +
                    "this._unsubscribeAll = new Subject();\n" +
                "}\n\n" +

                "// -----------------------------------------------------------------------------------------------------\n" +
                "// @ Lifecycle hooks\n" +
                "// -----------------------------------------------------------------------------------------------------\n\n" +

                /**
                 * On init
                 */
    ngOnInit() : void
    {
        // Subscribe to update product on changes
        this._ecommerceProductService.onProductChanged
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(product => {

        if (product)
        {
            this.product = new Product(product);
            this.pageType = 'edit';
        }
        else
        {
            this.pageType = 'new';
            this.product = new Product();
        }

        this.productForm = this.createProductForm();
    });
    }

    /**
     * On destroy
     */
    ngOnDestroy() : void
    {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Create product form
     *
     * @returns {FormGroup}
     */
    createProductForm() : FormGroup
    {
        return this._formBuilder.group({
            id              : [this.product.id],
            name            : [this.product.name],
            handle          : [this.product.handle],
            description     : [this.product.description],
            categories      : [this.product.categories],
            tags            : [this.product.tags],
            images          : [this.product.images],
            priceTaxExcl    : [this.product.priceTaxExcl],
            priceTaxIncl    : [this.product.priceTaxIncl],
            taxRate         : [this.product.taxRate],
            comparedPrice   : [this.product.comparedPrice],
            quantity        : [this.product.quantity],
            sku             : [this.product.sku],
            width           : [this.product.width],
            height          : [this.product.height],
            depth           : [this.product.depth],
            weight          : [this.product.weight],
            extraShippingFee: [this.product.extraShippingFee],
            active          : [this.product.active]
        });
    }

/**
 * Save product
 */
saveProduct() : void
    {
        const data = this.productForm.getRawValue();
data.handle = FuseUtils.handleize(data.name);

        this._ecommerceProductService.saveProduct(data)
            .then(() => {

                // Trigger the subscription with new data
                this._ecommerceProductService.onProductChanged.next(data);

                // Show the success message
                this._matSnackBar.open('Product saved', 'OK', {
                    verticalPosition: 'top',
                    duration        : 2000
                });
            });
    }

    /**
     * Add product
     */
    addProduct() : void
    {
        const data = this.productForm.getRawValue();
data.handle = FuseUtils.handleize(data.name);

        this._ecommerceProductService.addProduct(data)
            .then(() => {

                // Trigger the subscription with new data
                this._ecommerceProductService.onProductChanged.next(data);

                // Show the success message
                this._matSnackBar.open('Product added', 'OK', {
                    verticalPosition: 'top',
                    duration        : 2000
                });

                // Change the location with new one
                this._location.go('apps/e-commerce/products/' + this.product.id + '/' + this.product.handle);
});
    }
}
";

            return s;
        }
    }
}
