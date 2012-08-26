.PHONY: all dist clean clean-dist

# Tools
SHELL     = /bin/sh
FONTFORGE = fontforge

# Xolonium
FONTS   = Xolonium-Regular Xolonium-Bold
VERSION = 2.0

# Directories
VPATH       = $(DIR_SRC)
DIR_SRC     = src
DIR_SCRIPTS = scripts
DIR_OTF     = otf
DIR_DIST    = xolonium-fonts-$(VERSION)

# Files
FILES_MISC = ChangeLog COPYING COVERAGE CREDITS Makefile README
FILES_SFD  = $(foreach font, $(FONTS), $(DIR_SRC)/$(font).sfd)
FILES_OTF  = $(foreach font, $(FONTS), $(DIR_OTF)/$(font).otf)
FILES_FEA  = $(DIR_SRC)/Xolonium-Regular-kern.fea
SCRIPT_OTF = $(DIR_SCRIPTS)/generate-otf.ff


all: $(FILES_OTF)


$(DIR_OTF)/Xolonium-Regular.otf: Xolonium-Regular.sfd Xolonium-Regular-kern.fea
	install -d $(dir $@)
	$(FONTFORGE) -script $(SCRIPT_OTF) $+ $@


$(DIR_OTF)/Xolonium-Bold.otf: Xolonium-Bold.sfd Xolonium-Regular-kern.fea
	install -d $(dir $@)
	$(FONTFORGE) -script $(SCRIPT_OTF) $+ $@


dist: all clean-dist
	install -d $(DIR_DIST)/$(DIR_SRC)
	install -d $(DIR_DIST)/$(DIR_OTF)
	install -d $(DIR_DIST)/$(DIR_SCRIPTS)

	install -t $(DIR_DIST)                $(FILES_MISC)
	install -t $(DIR_DIST)/$(DIR_SRC)     $(FILES_SFD) $(FILES_FEA)
	install -t $(DIR_DIST)/$(DIR_OTF)     $(FILES_OTF)
	install -t $(DIR_DIST)/$(DIR_SCRIPTS) $(SCRIPT_OTF)

	zip -9r $(DIR_DIST).zip $(DIR_DIST)


clean: clean-dist


clean-dist:
	rm -rf -- $(DIR_DIST)*
